using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000034 RID: 52
	internal class SizeOf
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00013138 File Offset: 0x00011338
		public static void Sizeof(ModuleDef md)
		{
			foreach (ModuleDef moduleDef in md.Assembly.Modules)
			{
				foreach (TypeDef typeDef in moduleDef.Types)
				{
					bool flag = typeDef.Namespace.Contains(".My");
					if (!flag)
					{
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							bool flag2 = methodDef.HasBody && methodDef.Body.HasInstructions;
							if (flag2)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag3 = methodDef.Body.Instructions[i].OpCode == OpCodes.Ldc_I4;
									if (flag3)
									{
										SizeOf.body = methodDef.Body;
										int ldcI4Value = SizeOf.body.Instructions[i].GetLdcI4Value();
										int num = SizeOf.rndx.Next(1, 3);
										int num2 = ldcI4Value - num;
										SizeOf.body.Instructions[i].Operand = num2;
										SizeOf.Start(i, num, num2, md, methodDef);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00013330 File Offset: 0x00011530
		public static void Start(int i, int sub, int calculado, ModuleDef md, MethodDef method)
		{
			switch (sub)
			{
			case 1:
			{
				Local local = new Local(md.CorLibTypes.Object);
				Local local2 = new Local(md.CorLibTypes.Object);
				Local local3 = new Local(md.CorLibTypes.Object);
				Local local4 = new Local(md.CorLibTypes.Object);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				method.Body.Variables.Add(local3);
				method.Body.Variables.Add(local4);
				SizeOf.body.Instructions.Insert(i + 1, new Instruction(OpCodes.Sizeof, md.Import(typeof(GCNotificationStatus))));
				SizeOf.body.Instructions.Insert(i + 2, new Instruction(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
				SizeOf.body.Instructions.Insert(i + 5, new Instruction(OpCodes.Sizeof, md.Import(typeof(sbyte))));
				SizeOf.body.Instructions.Insert(i + 6, new Instruction(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 7, new Instruction(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 8, OpCodes.Sub.ToInstruction());
				SizeOf.body.Instructions.Insert(i + 9, new Instruction(OpCodes.Sizeof, md.Import(typeof(sbyte))));
				SizeOf.body.Instructions.Insert(i + 10, new Instruction(OpCodes.Stloc_S, local3));
				SizeOf.body.Instructions.Insert(i + 11, new Instruction(OpCodes.Ldloc_S, local3));
				SizeOf.body.Instructions.Insert(i + 12, OpCodes.Sub.ToInstruction());
				SizeOf.body.Instructions.Insert(i + 13, new Instruction(OpCodes.Sizeof, md.Import(typeof(sbyte))));
				SizeOf.body.Instructions.Insert(i + 14, new Instruction(OpCodes.Stloc_S, local4));
				SizeOf.body.Instructions.Insert(i + 15, new Instruction(OpCodes.Ldloc_S, local4));
				SizeOf.body.Instructions.Insert(i + 16, OpCodes.Sub.ToInstruction());
				break;
			}
			case 2:
			{
				Local local = new Local(md.CorLibTypes.Object);
				method.Body.Variables.Add(local);
				SizeOf.body.Instructions.Insert(i + 1, new Instruction(OpCodes.Sizeof, md.Import(typeof(char))));
				SizeOf.body.Instructions.Insert(i + 2, new Instruction(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
				break;
			}
			case 3:
			{
				Local local = new Local(md.CorLibTypes.Object);
				Local local2 = new Local(md.CorLibTypes.Object);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				SizeOf.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(int))));
				SizeOf.body.Instructions.Insert(i + 2, new Instruction(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(byte))));
				SizeOf.body.Instructions.Insert(i + 5, new Instruction(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 6, new Instruction(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Sub));
				SizeOf.body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Add));
				break;
			}
			case 4:
			{
				Local local = new Local(md.CorLibTypes.Object);
				Local local2 = new Local(md.CorLibTypes.Object);
				Local local3 = new Local(md.CorLibTypes.Object);
				Local local4 = new Local(md.CorLibTypes.Object);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				method.Body.Variables.Add(local3);
				method.Body.Variables.Add(local4);
				SizeOf.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Add));
				SizeOf.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(decimal))));
				SizeOf.body.Instructions.Insert(i + 3, new Instruction(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 4, new Instruction(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(GCCollectionMode))));
				SizeOf.body.Instructions.Insert(i + 6, new Instruction(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 7, new Instruction(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Sub));
				SizeOf.body.Instructions.Insert(i + 9, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(int))));
				SizeOf.body.Instructions.Insert(i + 10, new Instruction(OpCodes.Stloc_S, local3));
				SizeOf.body.Instructions.Insert(i + 11, new Instruction(OpCodes.Ldloc_S, local3));
				SizeOf.body.Instructions.Insert(i + 12, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(byte))));
				SizeOf.body.Instructions.Insert(i + 13, new Instruction(OpCodes.Stloc_S, local4));
				SizeOf.body.Instructions.Insert(i + 14, new Instruction(OpCodes.Ldloc_S, local4));
				SizeOf.body.Instructions.Insert(i + 15, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(byte))));
				SizeOf.body.Instructions.Insert(i + 16, new Instruction(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 17, new Instruction(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 18, Instruction.Create(OpCodes.Sub));
				SizeOf.body.Instructions.Insert(i + 19, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(byte))));
				SizeOf.body.Instructions.Insert(i + 20, new Instruction(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 21, new Instruction(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 22, Instruction.Create(OpCodes.Sizeof, md.Import(typeof(byte))));
				SizeOf.body.Instructions.Insert(i + 23, new Instruction(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 24, new Instruction(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 25, Instruction.Create(OpCodes.Add));
				break;
			}
			case 5:
			{
				Local local = new Local(md.CorLibTypes.Object);
				Local local2 = new Local(md.CorLibTypes.Object);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				SizeOf.body.Instructions.Insert(i + 1, new Instruction(OpCodes.Sizeof, md.Import(typeof(EnvironmentVariableTarget))));
				SizeOf.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Stloc_S, local));
				SizeOf.body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldloc_S, local));
				SizeOf.body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
				SizeOf.body.Instructions.Insert(i + 5, new Instruction(OpCodes.Sizeof, md.Import(typeof(sbyte))));
				SizeOf.body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Stloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldloc_S, local2));
				SizeOf.body.Instructions.Insert(i + 9, OpCodes.Add.ToInstruction());
				break;
			}
			}
		}

		// Token: 0x04000071 RID: 113
		public static CilBody body;

		// Token: 0x04000072 RID: 114
		public static Random rndx = new Random();
	}
}
