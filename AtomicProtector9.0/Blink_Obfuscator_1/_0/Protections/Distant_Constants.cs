using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000023 RID: 35
	internal class Distant_Constants
	{
		// Token: 0x06000097 RID: 151 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		public static void DisConstants(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					for (int i = 1; i < 1; i++)
					{
						CilBody body = methodDef.Body;
						body.SimplifyBranches();
						Random random = new Random();
						int j = 0;
						while (j < body.Instructions.Count)
						{
							bool flag = body.Instructions[j].IsLdcI4();
							if (flag)
							{
								int ldcI4Value = body.Instructions[j].GetLdcI4Value();
								int num = random.Next(5, 40);
								body.Instructions[j].OpCode = OpCodes.Ldc_I4;
								body.Instructions[j].Operand = num * ldcI4Value;
								body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Ldc_I4, num));
								body.Instructions.Insert(j + 2, Instruction.Create(OpCodes.Div));
								j += 3;
							}
							else
							{
								j++;
							}
						}
						Random random2 = new Random();
						int num2 = 0;
						ITypeDefOrRef type = null;
						for (int k = 0; k < methodDef.Body.Instructions.Count; k++)
						{
							Instruction instruction = methodDef.Body.Instructions[k];
							bool flag2 = instruction.IsLdcI4();
							if (flag2)
							{
								switch (random2.Next(1, 8))
								{
								case 1:
									type = methodDef.Module.Import(typeof(int));
									num2 = 4;
									break;
								case 2:
									type = methodDef.Module.Import(typeof(sbyte));
									num2 = 1;
									break;
								case 3:
									type = methodDef.Module.Import(typeof(byte));
									num2 = 1;
									break;
								case 4:
									type = methodDef.Module.Import(typeof(bool));
									num2 = 1;
									break;
								case 5:
									type = methodDef.Module.Import(typeof(decimal));
									num2 = 16;
									break;
								case 6:
									type = methodDef.Module.Import(typeof(short));
									num2 = 2;
									break;
								case 7:
									type = methodDef.Module.Import(typeof(long));
									num2 = 8;
									break;
								}
								int num3 = random2.Next(1, 1000);
								bool flag3 = Convert.ToBoolean(random2.Next(0, 2));
								switch ((num2 != 0) ? ((Convert.ToInt32(instruction.Operand) % num2 == 0) ? random2.Next(1, 5) : random2.Next(1, 4)) : random2.Next(1, 4))
								{
								case 1:
									methodDef.Body.Instructions.Insert(k + 1, Instruction.Create(OpCodes.Sizeof, type));
									methodDef.Body.Instructions.Insert(k + 2, Instruction.Create(OpCodes.Add));
									instruction.Operand = Convert.ToInt32(instruction.Operand) - num2 + (flag3 ? (-num3) : num3);
									goto IL_493;
								case 2:
									methodDef.Body.Instructions.Insert(k + 1, Instruction.Create(OpCodes.Sizeof, type));
									methodDef.Body.Instructions.Insert(k + 2, Instruction.Create(OpCodes.Sub));
									instruction.Operand = Convert.ToInt32(instruction.Operand) + num2 + (flag3 ? (-num3) : num3);
									goto IL_493;
								case 3:
									methodDef.Body.Instructions.Insert(k + 1, Instruction.Create(OpCodes.Sizeof, type));
									methodDef.Body.Instructions.Insert(k + 2, Instruction.Create(OpCodes.Add));
									instruction.Operand = Convert.ToInt32(instruction.Operand) - num2 + (flag3 ? (-num3) : num3);
									goto IL_493;
								case 4:
									methodDef.Body.Instructions.Insert(k + 1, Instruction.Create(OpCodes.Sizeof, type));
									methodDef.Body.Instructions.Insert(k + 2, Instruction.Create(OpCodes.Mul));
									instruction.Operand = Convert.ToInt32(instruction.Operand) / num2;
									break;
								default:
									goto IL_493;
								}
								IL_48A:
								k += 2;
								goto IL_4E2;
								IL_493:
								methodDef.Body.Instructions.Insert(k + 3, Instruction.CreateLdcI4(num3));
								methodDef.Body.Instructions.Insert(k + 4, Instruction.Create(flag3 ? OpCodes.Add : OpCodes.Sub));
								k += 2;
								goto IL_48A;
							}
							IL_4E2:;
						}
						body.OptimizeBranches();
					}
				}
			}
		}
	}
}
