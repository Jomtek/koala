using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicVM.Virtualization
{
	// Token: 0x02000046 RID: 70
	internal class Locals
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000194C0 File Offset: 0x000176C0
		public static void Protect(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.GetTypes())
			{
				bool flag = !typeDef.IsGlobalModuleType;
				if (flag)
				{
					using (IEnumerator<MethodDef> enumerator2 = typeDef.Methods.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							MethodDef method = enumerator2.Current;
							bool hasBody = method.HasBody;
							if (hasBody)
							{
								method.Body.SimplifyMacros(method.Parameters);
								IList<Instruction> instructions = method.Body.Instructions;
								for (int i = 0; i < instructions.Count; i++)
								{
									Local local = instructions[i].Operand as Local;
									bool flag2 = local != null;
									if (flag2)
									{
										bool flag3 = !Locals.convertedLocals.ContainsKey(local);
										FieldDef fieldDef;
										if (flag3)
										{
											fieldDef = new FieldDefUser("https://pastebin.com/" + Assembly.Random(8), new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
											md.GlobalType.Fields.Add(fieldDef);
											Locals.convertedLocals.Add(local, fieldDef);
										}
										else
										{
											fieldDef = Locals.convertedLocals[local];
										}
										OpCode opCode = null;
										switch (instructions[i].OpCode.Code)
										{
										case Code.Ldloc:
											opCode = OpCodes.Ldsfld;
											break;
										case Code.Ldloca:
											opCode = OpCodes.Ldsflda;
											break;
										case Code.Stloc:
											opCode = OpCodes.Stsfld;
											break;
										}
										instructions[i].OpCode = opCode;
										instructions[i].Operand = fieldDef;
									}
								}
								Locals.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
								{
									method.Body.Variables.Remove(x.Key);
								});
								Locals.convertedLocals = new Dictionary<Local, FieldDef>();
							}
						}
					}
				}
			}
		}

		// Token: 0x040000BA RID: 186
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
