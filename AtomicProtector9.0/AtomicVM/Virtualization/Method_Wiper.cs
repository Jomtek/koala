using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicVM.Virtualization
{
	// Token: 0x02000048 RID: 72
	internal class Method_Wiper
	{
		// Token: 0x06000163 RID: 355 RVA: 0x0001972C File Offset: 0x0001792C
		public static MethodDef GenerateMethod(TypeDef declaringType, object targetMethod, [Optional] bool hasThis, [Optional] bool isVoid)
		{
			MemberRef memberRef = (MemberRef)targetMethod;
			MethodDef methodDef = new MethodDefUser("Atomic_" + Method_Wiper.rnd.Next(1, 10000).ToString(), MethodSig.CreateStatic(memberRef.ReturnType), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
			methodDef.Body = new CilBody();
			if (hasThis)
			{
				methodDef.MethodSig.Params.Add(declaringType.Module.Import(declaringType.Module.CorLibTypes.Object));
			}
			foreach (TypeSig item in memberRef.MethodSig.Params)
			{
				methodDef.MethodSig.Params.Add(item);
			}
			methodDef.Parameters.UpdateParameterTypes();
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = OpCodes.Call.ToInstruction(declaringType.Module.Import(typeof(string).GetMethod("IsNullOrEmpty", new Type[]
			{
				typeof(string)
			})));
			foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
			{
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));
			}
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Call, memberRef));
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			return methodDef;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00019900 File Offset: 0x00017B00
		public static void Fix(ModuleDef moduleDef)
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver();
			ModuleContext moduleContext = new ModuleContext(assemblyResolver);
			assemblyResolver.DefaultModuleContext = moduleContext;
			assemblyResolver.EnableTypeDefCache = true;
			List<AssemblyRef> list = moduleDef.GetAssemblyRefs().ToList<AssemblyRef>();
			moduleDef.Context = moduleContext;
			foreach (AssemblyRef assemblyRef in list)
			{
				bool flag = assemblyRef == null;
				bool flag2 = !flag;
				if (flag2)
				{
					AssemblyDef assemblyDef = assemblyResolver.Resolve(assemblyRef.FullName, moduleDef);
					bool flag3 = assemblyDef == null;
					bool flag4 = !flag3;
					if (flag4)
					{
						moduleDef.Context.AssemblyResolver.AddToCache(assemblyDef);
					}
				}
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000199CC File Offset: 0x00017BCC
		public static void Execute(ModuleDef md)
		{
			Method_Wiper.Fix(md);
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = Method_Wiper.usedMethods.Contains(methodDef);
					if (!flag)
					{
						bool flag2 = !methodDef.HasBody;
						if (flag2)
						{
							return;
						}
						foreach (Instruction instruction in methodDef.Body.Instructions.ToArray<Instruction>())
						{
							bool flag3 = instruction.OpCode == OpCodes.Call;
							if (flag3)
							{
								bool flag4 = instruction.Operand is MemberRef;
								if (flag4)
								{
									MemberRef memberRef = (MemberRef)instruction.Operand;
									bool flag5 = !memberRef.FullName.Contains("Collections.Generic") && !memberRef.Name.Contains("ToString") && !memberRef.FullName.Contains("Thread::Start") && !memberRef.FullName.Contains("Properties.Settings");
									if (flag5)
									{
										MethodDef methodDef2 = Method_Wiper.GenerateMethod(typeDef, memberRef, memberRef.HasThis, memberRef.FullName.StartsWith("System.Void"));
										bool flag6 = methodDef2 != null;
										if (flag6)
										{
											Method_Wiper.usedMethods.Add(methodDef2);
											typeDef.Methods.Add(methodDef2);
											instruction.Operand = methodDef2;
											methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040000BC RID: 188
		public static Random rnd = new Random();

		// Token: 0x040000BD RID: 189
		private static List<MethodDef> usedMethods = new List<MethodDef>();
	}
}
