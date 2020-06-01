using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200002A RID: 42
	internal class LocalToFields
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x0000E2CC File Offset: 0x0000C4CC
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
										bool flag3 = !LocalToFields.convertedLocals.ContainsKey(local);
										FieldDef fieldDef;
										if (flag3)
										{
											fieldDef = new FieldDefUser("Blink.̴̵̘̩͍͖̻̦̣͕̗̖͔̘͓͗̈͛͂́̾ͫ͛̄͆ͤ̑͘͘.̡̛̮͇̫̮͔̲͕̫̹̘̞̱̾̈ͬ̆ͦ̈́͂̀̌̈́̆͋͆͋́.̶̴̨̩̻̮̹͔̞̻͖̭̻̲̉͆̓ͨͥ̈́̈́ͤ̅͑̆̑̔̔̍̀͘͝ḩ̷̸͎̞̬͚͙́͒̃̿̑ส็็็็็็็็็็็็็็็็็็็i͇̠̱̽͛ͣͯͭ̐͐ͩͪ̀͒̿̍̆̌ͣ̕͞ţ̈́̄ͦ͑͐ͤ̇ͯ̚͜͢͏̺͎̰̯̰̳̣̺͉͉̻̯̱͉̱̳̠̫l̢̮̝̰̖̲̯͉̱͉̤̗̯͇ͫ͋͑͋͊́͑͠e̛̼͉̝̯̼͚͇̜̹̬̼͚̥̝̟̩̮̎̾ͧ͟͝ͅr̷͎̣͙͇̦̱̺͚̬͍͎̗̺͍͈͍̔̃̆ͬ̃͌ͦ͗ͧ̓͋̓͟͟͡ͅ ̵̩̼͙̣̦͕̃ͨͧ̂ͭ͂̀͜ḣ͚͖͉͓̫̲̦͓́̆̈ͯ͒͂ͫ͛ͣ̓ͫ̄́́̕͜͜͜ą̴̢̺̼͎̩͓̱͍̯͓̻̖͓̯̿ͩͩͦ̕ͅt͂ͫ̔͋͆̀ͩͨ͂̎̓ͧ̿̈́̓̏̃ͯ̈͘͘҉͚̬̝͙̟̗̰̹̱̗ ̵̠̤̼̬̩͔̲̖̎̍̈̌̾̎̋̂̓ͬ̒ͫ̽ͭ́̕͠n̛̲͙̻̤̮̥̠͇͇͖͎̘̠̲ͥͣ̋͛ͨ̀i̧͓͖͈̭͔͉̼ͪͫ̓͂̔̿͠ͅč̨̆̉͂̑͞͏̻̠̖̼̹̻̹̯͇͙̰̪̯hͭ͌ͦ̉̊͐͂҉̸͇̹̹̬̖͕̱͕͕̠̗̀͘͝tͤͫͫͧ̈́͂͛ͭ̉ͧ͛ͫ̚҉̴͚̯̭̲̫̦͖̮̭͖̗͎̳̟̀͘s̸ͧ͗̌͊ͨ̐̅̇͟҉͈̤̘͉̤̯̝͈͚ ͤ͆͆ͨ̓҉̤̣̩̠̩̯̩̱͕̹͜͝                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                f̡̞͔̮͖̩͔̀̆̅̓̈ͪͥ͋͊̉ͪ̇̉̃̔͋̃̈́͟͠͝ä̵̸̺̖͓͖̳̬̲̲͎͎͔̈͋͑͋ͦͅͅl̻̟̲̞̘͚̤͎͉̯̫̹̜̥̳͈̙ͧ͋̇ͫ͋̎ͯ̋͂ͮ̈͂̾ͯ̎̊̾ͯ͘͢ͅs̴̡͍̖̖͕̱̫̤̣͛ͩͤ͆̅ͣ͐̿ͣ͐̔ͨ̄ͫͩ̄̍͘̕͜c̵̷̨͇̰̰̼̝̝̼̤͎̯̺̰͕̤̤͇ͧͦ̄̇̓ͩ̎͂̊ͯ͋͋̋̀ͬͧ͗̔̚͝͡ͅͅh͓͙̩̭̬̠̜͇̗̮̐ͥͧͭ̆͆̔ͬ́̄͊ͮ͡͝͠ ̩̹̥̯̲͉͔̟͕͎̪͔̱̬̌ͭ͗̔̏̊̚͡͞g̴̴̫͖̥̲̦͉̩̲̪̹̙̘̩̣̯̜̱͌ͩ͑̆̿̏̽ͤ͂ͩ́͢͠e̤̳͈̹͉̹̪̥̜̲͙͕͍̟̱̱̳͗̽ͤ̈́̽̽̊͢͡ḿ͈̮͓͇̞̯͍̦͖̟͔̫͈̏̑̋̂̒ͬ͌̌̓̄͢͞ą̶̴͈̳̥͙͚͓͉̟̬̤͋͒ͫ̓̿́̒͐͒͘͡c̡̞̪̞̣̦̖̙̬̜̜̋̿͐̇̓̋̃͆̚h̨̛̝͓͚̱͍͕̝̬̯̩̓̽̉͌͊̇͐̒̈͋͋̌ͩ̋ͭt̶̄́͑̐҉҉̟̭̟͓̜̩͖̲͔̀ ̷̧̡̦̞̝̯̥͍̻͚̠̞̣̯͎̇̓̇̐̓́͝h̡̺̳͇̤̬̻̮̭͇̿̑̔̽ͮ̉̏̃͂̄̌̍͒̑̇ͪ̑͡͞ĭ̵͔͙̞̻̰̻̬̖͇̩͔̪̮̩̘̔ͪͥ̈́͋͞t̸̝̪̹̲̓͌ͤ̍ͫͧ͋͋ͣ͆̈́ͩͯ̒ͮ̊ͧ̕͢͜ͅVM", new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
											md.GlobalType.Fields.Add(fieldDef);
											LocalToFields.convertedLocals.Add(local, fieldDef);
										}
										else
										{
											fieldDef = LocalToFields.convertedLocals[local];
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
								LocalToFields.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
								{
									method.Body.Variables.Remove(x.Key);
								});
								LocalToFields.convertedLocals = new Dictionary<Local, FieldDef>();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000058 RID: 88
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
