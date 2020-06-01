using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000035 RID: 53
	internal class Stack_Underflow
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00013D74 File Offset: 0x00011F74
		public static void StackUnderflow(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = methodDef != null && !methodDef.HasBody;
					if (flag)
					{
						break;
					}
					CilBody body = methodDef.Body;
					Instruction instruction = body.Instructions[0];
					Instruction instruction2 = Instruction.Create(OpCodes.Br_S, instruction);
					Instruction item = Instruction.Create(OpCodes.Pop);
					Random random = new Random();
					Instruction item2;
					switch (random.Next(0, 5))
					{
					case 0:
						item2 = Instruction.Create(OpCodes.Ldnull);
						break;
					case 1:
						item2 = Instruction.Create(OpCodes.Ldc_I4_0);
						break;
					case 2:
						item2 = Instruction.Create(OpCodes.Ldstr, "Blink");
						break;
					case 3:
						item2 = Instruction.Create(OpCodes.Ldc_I8, (long)((ulong)random.Next()));
						break;
					default:
						item2 = Instruction.Create(OpCodes.Ldc_I8, (long)random.Next());
						break;
					}
					body.Instructions.Insert(0, item2);
					body.Instructions.Insert(1, item);
					body.Instructions.Insert(2, instruction2);
					foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
					{
						bool flag2 = exceptionHandler.TryStart == instruction;
						if (flag2)
						{
							exceptionHandler.TryStart = instruction2;
						}
						else
						{
							bool flag3 = exceptionHandler.HandlerStart == instruction;
							if (flag3)
							{
								exceptionHandler.HandlerStart = instruction2;
							}
							else
							{
								bool flag4 = exceptionHandler.FilterStart == instruction;
								if (flag4)
								{
									exceptionHandler.FilterStart = instruction2;
								}
							}
						}
					}
				}
			}
		}
	}
}
