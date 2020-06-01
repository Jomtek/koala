using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicVM.Calli
{
	// Token: 0x02000042 RID: 66
	internal class Protection
	{
		// Token: 0x0600014E RID: 334 RVA: 0x00018C1C File Offset: 0x00016E1C
		public static void Protect(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				MethodDef[] array2 = typeDef.Methods.ToArray<MethodDef>();
				int j = 0;
				while (j < array2.Length)
				{
					MethodDef methodDef = array2[j];
					bool hasBody = methodDef.HasBody;
					if (hasBody)
					{
						bool hasInstructions = methodDef.Body.HasInstructions;
						if (hasInstructions)
						{
							bool flag = methodDef.FullName.Contains("My.");
							if (!flag)
							{
								bool flag2 = methodDef.FullName.Contains(".My");
								if (!flag2)
								{
									bool flag3 = methodDef.FullName.Contains("Costura");
									if (!flag3)
									{
										bool isConstructor = methodDef.IsConstructor;
										if (!isConstructor)
										{
											bool isGlobalModuleType = methodDef.DeclaringType.IsGlobalModuleType;
											if (!isGlobalModuleType)
											{
												int k = 0;
												while (k < methodDef.Body.Instructions.Count - 1)
												{
													try
													{
														bool flag4 = methodDef.Body.Instructions[k].ToString().Contains("ISupportInitialize");
														if (!flag4)
														{
															bool flag5 = methodDef.Body.Instructions[k].OpCode == OpCodes.Call || methodDef.Body.Instructions[k].OpCode == OpCodes.Callvirt;
															if (flag5)
															{
																try
																{
																	MemberRef memberRef = (MemberRef)methodDef.Body.Instructions[k].Operand;
																	methodDef.Body.Instructions[k].OpCode = OpCodes.Calli;
																	methodDef.Body.Instructions[k].Operand = memberRef.MethodSig;
																	methodDef.Body.Instructions.Insert(k, Instruction.Create(OpCodes.Ldftn, memberRef));
																}
																catch (Exception ex)
																{
																	string message = ex.Message;
																}
															}
														}
													}
													catch
													{
													}
													IL_1F4:
													k++;
													continue;
													goto IL_1F4;
												}
											}
										}
									}
								}
							}
						}
					}
					IL_221:
					j++;
					continue;
					goto IL_221;
				}
				foreach (MethodDef methodDef2 in md.GlobalType.Methods)
				{
					bool flag6 = methodDef2.Name == ".ctor";
					if (flag6)
					{
						md.GlobalType.Remove(methodDef2);
						break;
					}
				}
			}
		}
	}
}
