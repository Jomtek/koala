using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicVM.Virtualization
{
	// Token: 0x02000044 RID: 68
	internal class Assembly
	{
		// Token: 0x06000153 RID: 339 RVA: 0x00018F50 File Offset: 0x00017150
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwertyuiopasdfghjklzxcqwer1234590tyuiopasdfghjklz1234567890cvQWERTPASDFGHJZXCVNMbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmvbnm", length)
			select s[Assembly.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000F65C File Offset: 0x0000D85C
		public static bool CanRename(TypeDef type)
		{
			bool isGlobalModuleType = type.IsGlobalModuleType;
			bool result;
			if (isGlobalModuleType)
			{
				result = false;
			}
			else
			{
				try
				{
					bool flag = type.Namespace.Contains("My");
					if (flag)
					{
						return false;
					}
				}
				catch
				{
				}
				bool isGlobalModuleType2 = type.IsGlobalModuleType;
				if (isGlobalModuleType2)
				{
					result = false;
				}
				else
				{
					bool flag2 = type.Name == "GeneratedInternalTypeHelper" || type.Name == "Resources" || type.Name == "Settings";
					if (flag2)
					{
						result = false;
					}
					else
					{
						bool flag3 = type.Interfaces.Count > 0;
						if (flag3)
						{
							result = false;
						}
						else
						{
							bool isSpecialName = type.IsSpecialName;
							if (isSpecialName)
							{
								result = false;
							}
							else
							{
								bool isRuntimeSpecialName = type.IsRuntimeSpecialName;
								result = !isRuntimeSpecialName;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000F73C File Offset: 0x0000D93C
		public static bool CanRename(EventDef ev)
		{
			bool isRuntimeSpecialName = ev.IsRuntimeSpecialName;
			return !isRuntimeSpecialName;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000F760 File Offset: 0x0000D960
		public static bool CanRename(MethodDef method)
		{
			bool isConstructor = method.IsConstructor;
			bool result;
			if (isConstructor)
			{
				result = false;
			}
			else
			{
				bool isFamily = method.IsFamily;
				if (isFamily)
				{
					result = false;
				}
				else
				{
					bool isRuntimeSpecialName = method.IsRuntimeSpecialName;
					if (isRuntimeSpecialName)
					{
						result = false;
					}
					else
					{
						bool isForwarder = method.DeclaringType.IsForwarder;
						result = !isForwarder;
					}
				}
			}
			return result;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000F7B4 File Offset: 0x0000D9B4
		public static bool CanRename(FieldDef field)
		{
			bool flag = field.IsFamily || field.IsFamilyOrAssembly || field.IsPublic;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool isRuntimeSpecialName = field.IsRuntimeSpecialName;
				if (isRuntimeSpecialName)
				{
					result = false;
				}
				else
				{
					bool flag2 = field.DeclaringType.IsSerializable && !field.IsNotSerialized;
					if (flag2)
					{
						result = false;
					}
					else
					{
						bool flag3 = field.IsLiteral && field.DeclaringType.IsEnum;
						result = !flag3;
					}
				}
			}
			return result;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00018F9C File Offset: 0x0001719C
		public static void MarkAssembly(ModuleDef md)
		{
			md.Name = "\ud835\udd04\ud835\udd31\ud835\udd2c\ud835\udd2a\ud835\udd26\ud835\udd20 \ud835\udd12\ud835\udd1f\ud835\udd23\ud835\udd32\ud835\udd30\ud835\udd20\ud835\udd1e\ud835\udd31\ud835\udd2c��";
			md.Assembly.Name = "\ud835\udd04\ud835\udd31\ud835\udd2c\ud835\udd2a\ud835\udd26\ud835\udd20 \ud835\udd12\ud835\udd1f\ud835\udd23\ud835\udd32\ud835\udd30\ud835\udd20\ud835\udd1e\ud835\udd31\ud835\udd2c��";
			md.EntryPoint.DeclaringType = md.GlobalType;
			md.EntryPoint.Name = "AtomicLoad";
			TypeDef globalType = md.GlobalType;
			TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
			globalType.Name = "Atomic";
			globalType.BaseType = md.CorLibTypes.GetTypeRef("System", "Object");
			md.Types.Insert(0, typeDefUser);
			MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
			MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
			methodDef.Name = "Atomic";
			methodDef.IsRuntimeSpecialName = false;
			methodDef.IsSpecialName = false;
			methodDef.Access = MethodAttributes.PrivateScope;
			methodDef2.Body = new CilBody(true, new List<Instruction>
			{
				Instruction.Create(OpCodes.Call, methodDef),
				Instruction.Create(OpCodes.Ret)
			}, new List<ExceptionHandler>(), new List<Local>());
			for (int i = 0; i < globalType.Methods.Count; i++)
			{
				MethodDef methodDef3 = globalType.Methods[i];
				bool isNative = methodDef3.IsNative;
				if (isNative)
				{
					MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
					methodDefUser.Attributes = (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static);
					methodDefUser.Body = new CilBody();
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					globalType.Methods[i] = methodDefUser;
					typeDefUser.Methods.Add(methodDef3);
				}
			}
			foreach (TypeDef typeDef in md.Types)
			{
				int num = 1;
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					bool flag = Assembly.CanRename(fieldDef);
					if (flag)
					{
						num++;
						fieldDef.Name = "Atomic" + num.ToString();
					}
				}
				foreach (EventDef eventDef in typeDef.Events)
				{
					bool flag2 = Assembly.CanRename(eventDef);
					if (flag2)
					{
						num++;
						eventDef.Name = "Atomic" + num.ToString();
					}
				}
				foreach (MethodDef methodDef4 in typeDef.Methods)
				{
					bool flag3 = Assembly.CanRename(methodDef4);
					if (flag3)
					{
						num++;
						methodDef4.Name = "Atomic" + num.ToString();
					}
					foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef4.Parameters))
					{
						num++;
						parameter.Name = "Atomic" + num.ToString();
					}
					bool hasBody = methodDef4.HasBody;
					if (hasBody)
					{
						foreach (Local local in methodDef4.Body.Variables)
						{
							num++;
							local.Name = "Atomic" + num.ToString();
						}
					}
					foreach (GenericParam genericParam in methodDef4.GenericParameters)
					{
						genericParam.Name = ((char)(genericParam.Number + 1)).ToString();
					}
				}
			}
		}

		// Token: 0x040000B7 RID: 183
		public static Random random = new Random();
	}
}
