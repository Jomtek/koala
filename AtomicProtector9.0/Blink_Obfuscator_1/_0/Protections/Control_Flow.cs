using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000022 RID: 34
	internal class Control_Flow
	{
		// Token: 0x06000094 RID: 148 RVA: 0x0000C554 File Offset: 0x0000A754
		public static void Encrypt(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					if (flag)
					{
						return;
					}
					bool flag2 = !methodDef.Body.HasInstructions;
					if (flag2)
					{
						return;
					}
					for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
					{
						bool flag3 = methodDef.Body.Instructions[i].IsLdcI4();
						if (flag3)
						{
							int num = new Random(Guid.NewGuid().GetHashCode()).Next();
							int num2 = new Random(Guid.NewGuid().GetHashCode()).Next();
							int value = num ^ num2;
							Instruction instruction = OpCodes.Nop.ToInstruction();
							Local local = new Local(methodDef.Module.ImportAsTypeSig(typeof(int)));
							methodDef.Body.Variables.Add(local);
							methodDef.Body.Instructions.Insert(i + 1, OpCodes.Stloc.ToInstruction(local));
							methodDef.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, methodDef.Body.Instructions[i].GetLdcI4Value() - 4));
							methodDef.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, value));
							methodDef.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, num2));
							methodDef.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
							methodDef.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, num));
							methodDef.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, instruction));
							methodDef.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
							methodDef.Body.Instructions.Insert(i + 9, OpCodes.Stloc.ToInstruction(local));
							methodDef.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, methodDef.Module.Import(typeof(float))));
							methodDef.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
							methodDef.Body.Instructions.Insert(i + 12, instruction);
							i += 12;
						}
					}
				}
			}
		}

		// Token: 0x04000050 RID: 80
		private static Random generator = new Random();
	}
}
