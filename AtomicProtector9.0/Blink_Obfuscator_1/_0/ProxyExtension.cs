using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Blink_Obfuscator_1._0.Protections;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0
{
	// Token: 0x02000003 RID: 3
	public static class ProxyExtension
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002610 File Offset: 0x00000810
		public static string GenerateRandomString(int size)
		{
			byte[] array = new byte[4 * size];
			ProxyExtension.csp.GetNonZeroBytes(array);
			StringBuilder stringBuilder = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				stringBuilder.Append(ProxyExtension.chars[(int)(checked((IntPtr)(unchecked((ulong)BitConverter.ToUInt32(array, i * 4) % (ulong)((long)ProxyExtension.chars.Length)))))]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002678 File Offset: 0x00000878
		public static MethodDef CloneSignature(MethodDef from, MethodDef to)
		{
			to.Attributes = from.Attributes;
			bool isHideBySig = from.IsHideBySig;
			if (isHideBySig)
			{
				to.IsHideBySig = true;
			}
			bool isStatic = from.IsStatic;
			if (isStatic)
			{
				to.IsStatic = true;
			}
			return to;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000026BC File Offset: 0x000008BC
		public static MethodDef CopyMethod(this MethodDef originMethod, ModuleDef mod)
		{
			InjectContext injectContext = new InjectContext(mod, mod);
			Random random = new Random();
			MethodDefUser methodDefUser = new MethodDefUser
			{
				Signature = injectContext.Importer.Import(originMethod.Signature),
				Name = "BlinkVM_" + Renamer.rnd.Next(1, int.MaxValue).ToString()
			};
			methodDefUser.Parameters.UpdateParameterTypes();
			bool flag = originMethod.ImplMap != null;
			if (flag)
			{
				methodDefUser.ImplMap = new ImplMapUser(new ModuleRefUser(injectContext.TargetModule, originMethod.ImplMap.Module.Name), originMethod.ImplMap.Name, originMethod.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in originMethod.CustomAttributes)
			{
				methodDefUser.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)injectContext.Importer.Import(customAttribute.Constructor)));
			}
			bool hasBody = originMethod.HasBody;
			if (hasBody)
			{
				methodDefUser.Body = new CilBody
				{
					InitLocals = originMethod.Body.InitLocals,
					MaxStack = originMethod.Body.MaxStack
				};
				Dictionary<object, object> bodyMap = new Dictionary<object, object>();
				foreach (Local local in originMethod.Body.Variables)
				{
					Local local2 = new Local(injectContext.Importer.Import(local.Type));
					methodDefUser.Body.Variables.Add(local2);
					local2.Name = local.Name;
					bodyMap[local] = local2;
				}
				foreach (Instruction instruction in originMethod.Body.Instructions)
				{
					Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand)
					{
						SequencePoint = instruction.SequencePoint
					};
					bool flag2 = instruction2.Operand is IType;
					if (flag2)
					{
						instruction2.Operand = injectContext.Importer.Import((IType)instruction2.Operand);
					}
					else
					{
						bool flag3 = instruction2.Operand is IMethod;
						if (flag3)
						{
							instruction2.Operand = injectContext.Importer.Import((IMethod)instruction2.Operand);
						}
						else
						{
							bool flag4 = instruction2.Operand is IField;
							if (flag4)
							{
								instruction2.Operand = injectContext.Importer.Import((IField)instruction2.Operand);
							}
						}
					}
					methodDefUser.Body.Instructions.Add(instruction2);
					bodyMap[instruction] = instruction2;
				}
				Func<Instruction, Instruction> <>9__0;
				foreach (Instruction instruction3 in methodDefUser.Body.Instructions)
				{
					bool flag5 = instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand);
					if (flag5)
					{
						instruction3.Operand = bodyMap[instruction3.Operand];
					}
					else
					{
						bool flag6 = instruction3.Operand is Instruction[];
						if (flag6)
						{
							Instruction instruction4 = instruction3;
							IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
							Func<Instruction, Instruction> selector;
							if ((selector = <>9__0) == null)
							{
								selector = (<>9__0 = ((Instruction target) => (Instruction)bodyMap[target]));
							}
							instruction4.Operand = source.Select(selector).ToArray<Instruction>();
						}
					}
				}
				foreach (ExceptionHandler exceptionHandler in originMethod.Body.ExceptionHandlers)
				{
					methodDefUser.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
					{
						TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
						TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
						HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
						HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
						FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
					});
				}
				methodDefUser.Body.SimplifyMacros(methodDefUser.Parameters);
			}
			return methodDefUser;
		}

		// Token: 0x04000005 RID: 5
		private static readonly RandomNumberGenerator csp = RandomNumberGenerator.Create();

		// Token: 0x04000006 RID: 6
		private static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 !:;,ù^$*&é\"'(-è_çà)=?./§%¨£µ1234567890°+".ToCharArray();
	}
}
