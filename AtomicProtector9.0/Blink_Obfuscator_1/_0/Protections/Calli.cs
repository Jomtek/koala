using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200001B RID: 27
	internal class Calli
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00005D38 File Offset: 0x00003F38
		public static void Execute(ModuleDef module)
		{
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool flag = !typeDef.IsGlobalModuleType;
				if (flag)
				{
					foreach (MethodDef methodDef2 in typeDef.Methods)
					{
						bool flag2 = !methodDef2.IsConstructor && methodDef2.Body != null && methodDef2.HasBody && methodDef2.Body.HasInstructions && !methodDef2.FullName.Contains("My.") && !methodDef2.FullName.Contains(".My") && !methodDef2.IsConstructor && !methodDef2.DeclaringType.IsGlobalModuleType;
						if (flag2)
						{
							IList<Instruction> instructions = methodDef2.Body.Instructions;
							for (int i = 0; i < instructions.Count<Instruction>(); i++)
							{
								bool flag3 = instructions[i].OpCode == OpCodes.Call || instructions[i].OpCode == OpCodes.Callvirt;
								if (flag3)
								{
									MemberRef memberRef = instructions[i].Operand as MemberRef;
									bool flag4 = memberRef != null;
									if (flag4)
									{
										bool flag5 = new FileInfo(module.Location).Length > 1000000L;
										if (flag5)
										{
											instructions[i].OpCode = OpCodes.Ldftn;
											instructions[i].Operand = memberRef;
											instructions.Insert(++i, Instruction.Create(OpCodes.Calli, memberRef.MethodSig));
										}
										else
										{
											FieldDef fieldDef = new FieldDefUser("BlinkVM_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), new FieldSig(module.CorLibTypes.Object), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
											methodDef2.DeclaringType.Fields.Add(fieldDef);
											methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Stsfld, fieldDef));
											methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldftn, memberRef));
											instructions[i].OpCode = OpCodes.Ldsfld;
											instructions[i].Operand = fieldDef;
											instructions.Insert(++i, Instruction.Create(OpCodes.Calli, memberRef.MethodSig));
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
