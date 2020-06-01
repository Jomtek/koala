using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200002E RID: 46
	internal class Ref_Proxy
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002322 File Offset: 0x00000522
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00002329 File Offset: 0x00000529
		public static int Intensity { get; set; } = 20;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00002331 File Offset: 0x00000531
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00002338 File Offset: 0x00000538
		private static int Amount { get; set; }

		// Token: 0x060000BE RID: 190 RVA: 0x0000E870 File Offset: 0x0000CA70
		public static void Execute(ModuleDef md)
		{
			for (int i = 0; i < Ref_Proxy.Intensity; i++)
			{
				foreach (TypeDef typeDef in md.Types)
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
						{
							bool flag = !methodDef.HasBody;
							if (!flag)
							{
								int k = 0;
								while (k < methodDef.Body.Instructions.Count)
								{
									bool flag2 = methodDef.Body.Instructions[k].OpCode == OpCodes.Call;
									if (flag2)
									{
										try
										{
											MethodDef methodDef2 = methodDef.Body.Instructions[k].Operand as MethodDef;
											bool flag3 = !methodDef2.FullName.Contains(md.Assembly.Name);
											if (!flag3)
											{
												bool flag4 = methodDef2.Parameters.Count == 0 || methodDef2.Parameters.Count > 4;
												if (!flag4)
												{
													MethodDef methodDef3 = methodDef2.CopyMethod(md);
													methodDef2.Module.GlobalType.Methods.Add(methodDef3);
													ProxyExtension.CloneSignature(methodDef2, methodDef3);
													CilBody cilBody = new CilBody();
													cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
													for (int l = 0; l < methodDef2.Parameters.Count; l++)
													{
														switch (l)
														{
														case 0:
															cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
															break;
														case 1:
															cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
															break;
														case 2:
															cilBody.Instructions.Add(OpCodes.Ldarg_2.ToInstruction());
															break;
														case 3:
															cilBody.Instructions.Add(OpCodes.Ldarg_3.ToInstruction());
															break;
														}
													}
													cilBody.Instructions.Add(OpCodes.Call.ToInstruction(methodDef3));
													cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
													methodDef2.Body = cilBody;
													Ref_Proxy.Amount++;
												}
											}
										}
										catch
										{
										}
									}
									IL_255:
									k++;
									continue;
									goto IL_255;
								}
							}
						}
					}
				}
			}
		}
	}
}
