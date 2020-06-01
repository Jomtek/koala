using System;
using System.Collections.Generic;
using System.Linq;
using Blink_Obfuscator_1._0.Runtime.Constants;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000020 RID: 32
	internal class Constants__numbers_
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0000B774 File Offset: 0x00009974
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Numbers).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Numbers).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			Constants__numbers_.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "blinkobfuscator101010");
			Constants__numbers_.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "blinkobfuscator10101");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000B88C File Offset: 0x00009A8C
		public static void ObfuscateNumbers(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					if (!flag)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag2 = methodDef.Body.Instructions[i].IsLdcI4();
							if (flag2)
							{
								int ldcI4Value = methodDef.Body.Instructions[i].GetLdcI4Value();
								bool flag3 = ldcI4Value <= 0;
								if (!flag3)
								{
									methodDef.Body.Instructions[i].OpCode = OpCodes.Ldstr;
									methodDef.Body.Instructions[i].Operand = Constants__numbers_.Random(ldcI4Value);
									methodDef.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(md.Import(typeof(string).GetMethod("get_Length"))));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000BA30 File Offset: 0x00009C30
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = methodDef.FullName.Contains("My.");
						if (!flag)
						{
							bool flag2 = methodDef.FullName.Contains("InitializeCompnent");
							if (!flag2)
							{
								bool isConstructor = methodDef.IsConstructor;
								if (!isConstructor)
								{
									bool isGlobalModuleType2 = methodDef.DeclaringType.IsGlobalModuleType;
									if (!isGlobalModuleType2)
									{
										bool flag3 = !methodDef.HasBody;
										if (!flag3)
										{
											IList<Instruction> instructions = methodDef.Body.Instructions;
											for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
											{
												bool flag4 = methodDef.Body.Instructions[i].ToString().Contains("ResourceManager");
												if (flag4)
												{
													i = methodDef.Body.Instructions.Count;
												}
												else
												{
													bool flag5 = methodDef.Body.Instructions[i].ToString().Contains("GetObject");
													if (!flag5)
													{
														bool flag6 = instructions[i].OpCode == OpCodes.Ldstr;
														if (flag6)
														{
															Random random = new Random();
															for (int j = 1; j < 2; j++)
															{
																bool flag7 = j != 1;
																if (flag7)
																{
																	j++;
																}
																Local local = new Local(module.CorLibTypes.String);
																Local local2 = new Local(module.CorLibTypes.String);
																methodDef.Body.Variables.Add(local);
																methodDef.Body.Variables.Add(local2);
																instructions.Insert(i + j, Instruction.Create(OpCodes.Stloc_S, local));
																instructions.Insert(i + (j + 1), Instruction.Create(OpCodes.Ldloc_S, local));
															}
														}
														bool flag8 = methodDef.Body.Instructions[i].ToString().Contains("ResourceManager");
														if (!flag8)
														{
															bool flag9 = methodDef.Body.Instructions[i].ToString().Contains("GetObject");
															if (!flag9)
															{
																bool flag10 = instructions[i].IsLdcI4();
																if (flag10)
																{
																	Random random2 = new Random();
																	for (int k = 1; k < 2; k++)
																	{
																		bool flag11 = k != 1;
																		if (flag11)
																		{
																			k++;
																		}
																		Local local3 = new Local(module.CorLibTypes.Int32);
																		Local local4 = new Local(module.CorLibTypes.Int32);
																		methodDef.Body.Variables.Add(local3);
																		methodDef.Body.Variables.Add(local4);
																		instructions.Insert(i + k, Instruction.Create(OpCodes.Stloc_S, local3));
																		instructions.Insert(i + (k + 1), Instruction.Create(OpCodes.Ldloc_S, local3));
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
						}
					}
				}
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000BE10 File Offset: 0x0000A010
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwertyuiopasdfghjklzxcvbnmqrtyuiophjklxcvbnm", length)
			select s[Constants__numbers_.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000BE5C File Offset: 0x0000A05C
		public static void Melting(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					Constants__numbers_.StringOutliner(methodDef);
					Constants__numbers_.IntegerOutliner(methodDef);
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000BEDC File Offset: 0x0000A0DC
		public static void StringOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			if (hasBody)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag = instruction.OpCode != OpCodes.Ldstr;
					if (!flag)
					{
						bool flag2 = instruction.Operand == "BlinkVM";
						if (flag2)
						{
							break;
						}
						MethodDef methodDef2 = new MethodDefUser("BlinkVM_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.Object), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldstr, instruction.Operand.ToString()));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.Module.GlobalType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000C044 File Offset: 0x0000A244
		public static void IntegerOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			if (hasBody)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag = instruction.OpCode != OpCodes.Ldc_I4;
					if (!flag)
					{
						MethodDef methodDef2 = new MethodDefUser("BlinkVM_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.UInt32), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4, instruction.GetLdcI4Value()));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.Module.GlobalType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000C188 File Offset: 0x0000A388
		public static void FloatOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			if (hasBody)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag = instruction.OpCode != OpCodes.Ldc_R4;
					if (!flag)
					{
						MethodDef methodDef2 = new MethodDefUser("BlinkVM_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.Object), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldc_R4, instruction.Operand));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.DeclaringType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		public static void Inject(ModuleDef module)
		{
			Constants__numbers_.Execute(module);
			int num = new Random().Next(0, int.MaxValue);
			Constants__numbers_.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = !methodDef.HasBody;
						if (!flag)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count - 3; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldc_I4;
								if (flag2)
								{
									int num2 = (int)instructions[i].Operand;
									int num3 = num2 * 69;
									num3 *= 2;
									instructions[i].Operand = num3;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "BlinkVM"));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "BlinkVM"));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init));
								}
								bool flag3 = instructions[i].OpCode == OpCodes.Ldc_R4;
								if (flag3)
								{
									float num4 = (float)instructions[i].Operand;
									float num5 = num4 * 69f;
									num5 *= 2f;
									instructions[i].Operand = num5;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "BlinkVM"));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "BlinkVM"));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init1));
								}
							}
						}
					}
				}
			}
			Constants__numbers_.Melting(module);
		}

		// Token: 0x04000047 RID: 71
		public static Random random = new Random();

		// Token: 0x04000048 RID: 72
		private static IMethod _decrypt;

		// Token: 0x04000049 RID: 73
		private static ModuleDef _mod;

		// Token: 0x0400004A RID: 74
		public static MethodDef init;

		// Token: 0x0400004B RID: 75
		public static MethodDef init1;
	}
}
