using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200002F RID: 47
	internal class Renamer_v2
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x0000EB6C File Offset: 0x0000CD6C
		public static void Rename(TypeDef type, bool canRename = true)
		{
			bool flag = Renamer_v2.typeRename.ContainsKey(type);
			if (flag)
			{
				Renamer_v2.typeRename[type] = canRename;
			}
			else
			{
				Renamer_v2.typeRename.Add(type, canRename);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000EBA8 File Offset: 0x0000CDA8
		public static void Rename(MethodDef method, bool canRename = true)
		{
			bool flag = Renamer_v2.methodRename.ContainsKey(method);
			if (flag)
			{
				Renamer_v2.methodRename[method] = canRename;
			}
			else
			{
				Renamer_v2.methodRename.Add(method, canRename);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000EBE4 File Offset: 0x0000CDE4
		public static void Rename(FieldDef field, bool canRename = true)
		{
			bool flag = Renamer_v2.fieldRename.ContainsKey(field);
			if (flag)
			{
				Renamer_v2.fieldRename[field] = canRename;
			}
			else
			{
				Renamer_v2.fieldRename.Add(field, canRename);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000EC20 File Offset: 0x0000CE20
		public static void Execute(ModuleDef module)
		{
			bool isObfuscationActive = Renamer_v2.IsObfuscationActive;
			if (isObfuscationActive)
			{
				string text = Renamer_v2.GenerateString();
				foreach (TypeDef typeDef in module.Types)
				{
					bool flag2;
					bool flag = Renamer_v2.typeRename.TryGetValue(typeDef, out flag2);
					if (flag)
					{
						bool flag3 = flag2;
						if (flag3)
						{
							Renamer_v2.InternalRename(typeDef);
						}
					}
					else
					{
						Renamer_v2.InternalRename(typeDef);
					}
					typeDef.Namespace = "";
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag5;
						bool flag4 = Renamer_v2.methodRename.TryGetValue(methodDef, out flag5);
						if (flag4)
						{
							bool flag6 = flag5 && !methodDef.IsConstructor && !methodDef.IsSpecialName;
							if (flag6)
							{
								Renamer_v2.InternalRename(methodDef);
							}
						}
						else
						{
							bool flag7 = !methodDef.IsConstructor && !methodDef.IsSpecialName;
							if (flag7)
							{
								Renamer_v2.InternalRename(methodDef);
							}
						}
					}
					Renamer_v2.methodNewName.Clear();
					foreach (FieldDef fieldDef in typeDef.Fields)
					{
						bool flag9;
						bool flag8 = Renamer_v2.fieldRename.TryGetValue(fieldDef, out flag9);
						if (flag8)
						{
							bool flag10 = flag9;
							if (flag10)
							{
								Renamer_v2.InternalRename(fieldDef);
							}
						}
						else
						{
							Renamer_v2.InternalRename(fieldDef);
						}
					}
					Renamer_v2.fieldNewName.Clear();
				}
			}
			else
			{
				foreach (KeyValuePair<TypeDef, bool> keyValuePair in Renamer_v2.typeRename)
				{
					bool value = keyValuePair.Value;
					if (value)
					{
						Renamer_v2.InternalRename(keyValuePair.Key);
					}
				}
				foreach (KeyValuePair<MethodDef, bool> keyValuePair2 in Renamer_v2.methodRename)
				{
					bool value2 = keyValuePair2.Value;
					if (value2)
					{
						Renamer_v2.InternalRename(keyValuePair2.Key);
					}
				}
				foreach (KeyValuePair<FieldDef, bool> keyValuePair3 in Renamer_v2.fieldRename)
				{
					bool value3 = keyValuePair3.Value;
					if (value3)
					{
						Renamer_v2.InternalRename(keyValuePair3.Key);
					}
				}
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000EF48 File Offset: 0x0000D148
		private static void InternalRename(TypeDef type)
		{
			string text = Renamer_v2.GenerateString();
			while (Renamer_v2.typeNewName.Contains(text))
			{
				text = Renamer_v2.GenerateString();
			}
			Renamer_v2.typeNewName.Add(text);
			type.Name = text;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000EF8C File Offset: 0x0000D18C
		private static void InternalRename(MethodDef method)
		{
			string text = Renamer_v2.GenerateString();
			while (Renamer_v2.methodNewName.Contains(text))
			{
				text = Renamer_v2.GenerateString();
			}
			Renamer_v2.methodNewName.Add(text);
			method.Name = text;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000EFD0 File Offset: 0x0000D1D0
		private static void InternalRename(FieldDef field)
		{
			string text = Renamer_v2.GenerateString();
			while (Renamer_v2.fieldNewName.Contains(text))
			{
				text = Renamer_v2.GenerateString();
			}
			Renamer_v2.fieldNewName.Add(text);
			field.Name = text;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000F014 File Offset: 0x0000D214
		private static string GenerateString()
		{
			string text = "ส็็็็็็็็็็็็็็็็็็็i͇̠̱̽͛ͣͯͭ̐͐ͩͪ̀͒̿̍̆̌ͣ̕͞ţ̈́̄ͦ͑͐ͤ̇ͯ̚͜͢͏̺͎̰̯̰̳̣̺͉͉̻̯̱͉̱̳̠̫l̢̮̝̰̖̲̯͉̱͉̤̗̯͇ͫ͋͑͋͊́͑͠e̛̼͉̝̯̼͚͇̜̹̬̼͚̥̝̟̩̮̎̾ͧ͟͝ͅr̷͎̣͙͇̦̱̺͚̬͍͎̗̺͍͈͍̔̃̆ͬ̃͌ͦ͗ͧ̓͋̓͟͟͡ͅ ̵̩̼͙̣̦͕̃ͨͧ̂ͭ͂̀͜ḣ͚͖͉͓̫̲̦͓́̆̈ͯ͒͂ͫ͛ͣ̓ͫ̄́́̕͜͜͜ą̴̢̺̼͎̩͓̱͍̯͓̻̖͓̯̿ͩͩͦ̕ͅt͂ͫ̔͋͆̀ͩͨ͂̎̓ͧ̿̈́̓̏̃ͯ̈͘͘҉͚̬̝͙̟̗̰̹̱̗ ̵̠̤̼̬̩͔̲̖̎̍̈̌̾̎̋̂̓ͬ̒ͫ̽ͭ́̕͠n̛̲͙̻̤̮̥̠͇͇͖͎̘̠̲ͥͣ̋͛ͨ̀i̧͓͖͈̭͔͉̼ͪͫ̓͂̔̿͠ͅč̨̆̉͂̑͞͏̻̠̖̼̹̻̹̯͇͙̰̪̯hͭ͌ͦ̉̊͐͂҉̸͇̹̹̬̖͕̱͕͕̠̗̀͘͝tͤͫͫͧ̈́͂͛ͭ̉ͧ͛ͫ̚҉̴͚̯̭̲̫̦͖̮̭͖̗͎̳̟̀͘s̸ͧ͗̌͊ͨ̐̅̇͟҉͈̤̘͉̤̯̝͈͚ ͤ͆͆ͨ̓҉̤̣̩̠̩̯̩̱͕̹͜͝  ส็็็็็็็็็็็็็็็็็็็i͇̠̱̽͛ͣͯͭ̐͐ͩͪ̀͒̿̍̆̌ͣ̕͞ţ̈́̄ͦ͑͐ͤ̇ͯ̚͜͢͏̺͎̰̯̰̳̣̺͉͉̻̯̱͉̱̳̠̫l̢̮̝̰̖̲̯͉̱͉̤̗̯͇ͫ͋͑͋͊́͑͠e̛̼͉̝̯̼͚͇̜̹̬̼͚̥̝̟̩̮̎̾ͧ͟͝ͅr̷͎̣͙͇̦̱̺͚̬͍͎̗̺͍͈͍̔̃̆ͬ̃͌ͦ͗ͧ̓͋̓͟͟͡ͅ ̵̩̼͙̣̦͕̃ͨͧ̂ͭ͂̀͜ḣ͚͖͉͓̫̲̦͓́̆̈ͯ͒͂ͫ͛ͣ̓ͫ̄́́̕͜͜͜ą̴̢̺̼͎̩͓̱͍̯͓̻̖͓̯̿ͩͩͦ̕ͅt͂ͫ̔͋͆̀ͩͨ͂̎̓ͧ̿̈́̓̏̃ͯ̈͘͘҉͚̬̝͙̟̗̰̹̱̗ ̵̠̤̼̬̩͔̲̖̎̍̈̌̾̎̋̂̓ͬ̒ͫ̽ͭ́̕͠n̛̲͙̻̤̮̥̠͇͇͖͎̘̠̲ͥͣ̋͛ͨ̀i̧͓͖͈̭͔͉̼ͪͫ̓͂̔̿͠ͅč̨̆̉͂̑͞͏̻̠̖̼̹̻̹̯͇͙̰̪̯hͭ͌ͦ̉̊͐͂҉̸͇̹̹̬̖͕̱͕͕̠̗̀͘͝tͤͫͫͧ̈́͂͛ͭ̉ͧ͛ͫ̚҉̴͚̯̭̲̫̦͖̮̭͖̗͎̳̟̀͘s̸ͧ͗̌͊ͨ̐̅̇͟҉͈̤̘͉̤̯̝͈͚ ͤ͆͆ͨ̓҉̤̣̩̠̩̯̩̱͕̹͜͝  ส็็็็็็็็็็็็็็็็็็็i͇̠̱̽͛ͣͯͭ̐͐ͩͪ̀͒̿̍̆̌ͣ̕͞ţ̈́̄ͦ͑͐ͤ̇ͯ̚͜͢͏̺͎̰̯̰̳̣̺͉͉̻̯̱͉̱̳̠̫l̢̮̝̰̖̲̯͉̱͉̤̗̯͇ͫ͋͑͋͊́͑͠e̛̼͉̝̯̼͚͇̜̹̬̼͚̥̝̟̩̮̎̾ͧ͟͝ͅr̷͎̣͙͇̦̱̺͚̬͍͎̗̺͍͈͍̔̃̆ͬ̃͌ͦ͗ͧ̓͋̓͟͟͡ͅ ̵̩̼͙̣̦͕̃ͨͧ̂ͭ͂̀͜ḣ͚͖͉͓̫̲̦͓́̆̈ͯ͒͂ͫ͛ͣ̓ͫ̄́́̕͜͜͜ą̴̢̺̼͎̩͓̱͍̯͓̻̖͓̯̿ͩͩͦ̕ͅt͂ͫ̔͋͆̀ͩͨ͂̎̓ͧ̿̈́̓̏̃ͯ̈͘͘҉͚̬̝͙̟̗̰̹̱̗ ̵̠̤̼̬̩͔̲̖̎̍̈̌̾̎̋̂̓ͬ̒ͫ̽ͭ́̕͠n̛̲͙̻̤̮̥̠͇͇͖͎̘̠̲ͥͣ̋͛ͨ̀i̧͓͖͈̭͔͉̼ͪͫ̓͂̔̿͠ͅč̨̆̉͂̑͞͏̻̠̖̼̹̻̹̯͇͙̰̪̯hͭ͌ͦ̉̊͐͂҉̸͇̹̹̬̖͕̱͕͕̠̗̀͘͝tͤͫͫͧ̈́͂͛ͭ̉ͧ͛ͫ̚҉̴͚̯̭̲̫̦͖̮̭͖̗͎̳̟̀͘s̸ͧ͗̌͊ͨ̐̅̇͟҉͈̤̘͉̤̯̝͈͚ ͤ͆͆ͨ̓҉̤̣̩̠̩̯̩̱͕̹͜͝  ";
			for (int i = 0; i < 3; i++)
			{
				text += ((char)Renamer_v2.random.Next(8000, 8500)).ToString();
			}
			return text;
		}

		// Token: 0x0400005D RID: 93
		private static Dictionary<TypeDef, bool> typeRename = new Dictionary<TypeDef, bool>();

		// Token: 0x0400005E RID: 94
		private static List<string> typeNewName = new List<string>();

		// Token: 0x0400005F RID: 95
		private static Dictionary<MethodDef, bool> methodRename = new Dictionary<MethodDef, bool>();

		// Token: 0x04000060 RID: 96
		private static List<string> methodNewName = new List<string>();

		// Token: 0x04000061 RID: 97
		private static Dictionary<FieldDef, bool> fieldRename = new Dictionary<FieldDef, bool>();

		// Token: 0x04000062 RID: 98
		private static List<string> fieldNewName = new List<string>();

		// Token: 0x04000063 RID: 99
		public static bool IsObfuscationActive = true;

		// Token: 0x04000064 RID: 100
		private static Random random = new Random();
	}
}
