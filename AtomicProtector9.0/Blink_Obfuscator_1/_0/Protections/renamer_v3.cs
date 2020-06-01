using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using dnlib.DotNet;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000030 RID: 48
	internal class renamer_v3
	{
		// Token: 0x02000031 RID: 49
		public class RenamerPhase
		{
			// Token: 0x060000CC RID: 204 RVA: 0x0000F0C0 File Offset: 0x0000D2C0
			public static void Rename(TypeDef type, [Optional] bool canRename)
			{
				bool flag = renamer_v3.RenamerPhase.typeRename.ContainsKey(type);
				if (flag)
				{
					renamer_v3.RenamerPhase.typeRename[type] = canRename;
				}
				else
				{
					renamer_v3.RenamerPhase.typeRename.Add(type, canRename);
				}
			}

			// Token: 0x060000CD RID: 205 RVA: 0x0000F0FC File Offset: 0x0000D2FC
			public static void Rename(MethodDef method, [Optional] bool canRename)
			{
				bool flag = renamer_v3.RenamerPhase.methodRename.ContainsKey(method);
				if (flag)
				{
					renamer_v3.RenamerPhase.methodRename[method] = canRename;
				}
				else
				{
					renamer_v3.RenamerPhase.methodRename.Add(method, canRename);
				}
			}

			// Token: 0x060000CE RID: 206 RVA: 0x0000F138 File Offset: 0x0000D338
			public static void Rename(FieldDef field, [Optional] bool canRename)
			{
				bool flag = renamer_v3.RenamerPhase.fieldRename.ContainsKey(field);
				if (flag)
				{
					renamer_v3.RenamerPhase.fieldRename[field] = canRename;
				}
				else
				{
					renamer_v3.RenamerPhase.fieldRename.Add(field, canRename);
				}
			}

			// Token: 0x060000CF RID: 207 RVA: 0x0000F174 File Offset: 0x0000D374
			public static void Execute(ModuleDef module)
			{
				bool isObfuscationActive = renamer_v3.RenamerPhase.IsObfuscationActive;
				if (isObfuscationActive)
				{
					string s = renamer_v3.RenamerPhase.GenerateString();
					foreach (TypeDef typeDef in module.Types)
					{
						bool flag2;
						bool flag = renamer_v3.RenamerPhase.typeRename.TryGetValue(typeDef, out flag2);
						if (flag)
						{
							bool flag3 = flag2;
							if (flag3)
							{
								renamer_v3.RenamerPhase.InternalRename(typeDef);
							}
						}
						else
						{
							renamer_v3.RenamerPhase.InternalRename(typeDef);
						}
						typeDef.Namespace = s;
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							bool flag5;
							bool flag4 = renamer_v3.RenamerPhase.methodRename.TryGetValue(methodDef, out flag5);
							if (flag4)
							{
								bool flag6 = flag5 && !methodDef.IsConstructor && !methodDef.IsSpecialName;
								if (flag6)
								{
									renamer_v3.RenamerPhase.InternalRename(methodDef);
								}
							}
							else
							{
								bool flag7 = !methodDef.IsConstructor && !methodDef.IsSpecialName;
								if (flag7)
								{
									renamer_v3.RenamerPhase.InternalRename(methodDef);
								}
							}
						}
						renamer_v3.RenamerPhase.methodNewName.Clear();
						foreach (FieldDef fieldDef in typeDef.Fields)
						{
							bool flag9;
							bool flag8 = renamer_v3.RenamerPhase.fieldRename.TryGetValue(fieldDef, out flag9);
							if (flag8)
							{
								bool flag10 = flag9;
								if (flag10)
								{
									renamer_v3.RenamerPhase.InternalRename(fieldDef);
								}
							}
							else
							{
								renamer_v3.RenamerPhase.InternalRename(fieldDef);
							}
						}
						renamer_v3.RenamerPhase.fieldNewName.Clear();
					}
				}
				else
				{
					foreach (KeyValuePair<TypeDef, bool> keyValuePair in renamer_v3.RenamerPhase.typeRename)
					{
						bool value = keyValuePair.Value;
						if (value)
						{
							renamer_v3.RenamerPhase.InternalRename(keyValuePair.Key);
						}
					}
					foreach (KeyValuePair<MethodDef, bool> keyValuePair2 in renamer_v3.RenamerPhase.methodRename)
					{
						bool value2 = keyValuePair2.Value;
						if (value2)
						{
							renamer_v3.RenamerPhase.InternalRename(keyValuePair2.Key);
						}
					}
					foreach (KeyValuePair<FieldDef, bool> keyValuePair3 in renamer_v3.RenamerPhase.fieldRename)
					{
						bool value3 = keyValuePair3.Value;
						if (value3)
						{
							renamer_v3.RenamerPhase.InternalRename(keyValuePair3.Key);
						}
					}
				}
			}

			// Token: 0x060000D0 RID: 208 RVA: 0x0000F498 File Offset: 0x0000D698
			private static void InternalRename(TypeDef type)
			{
				string text = renamer_v3.RenamerPhase.GenerateString();
				while (renamer_v3.RenamerPhase.typeNewName.Contains(text))
				{
					text = renamer_v3.RenamerPhase.GenerateString();
				}
				renamer_v3.RenamerPhase.typeNewName.Add(text);
				type.Name = text;
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x0000F4DC File Offset: 0x0000D6DC
			private static void InternalRename(MethodDef method)
			{
				string text = renamer_v3.RenamerPhase.GenerateString();
				while (renamer_v3.RenamerPhase.methodNewName.Contains(text))
				{
					text = renamer_v3.RenamerPhase.GenerateString();
				}
				renamer_v3.RenamerPhase.methodNewName.Add(text);
				method.Name = text;
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x0000F520 File Offset: 0x0000D720
			private static void InternalRename(FieldDef field)
			{
				string text = renamer_v3.RenamerPhase.GenerateString();
				while (renamer_v3.RenamerPhase.fieldNewName.Contains(text))
				{
					text = renamer_v3.RenamerPhase.GenerateString();
				}
				renamer_v3.RenamerPhase.fieldNewName.Add(text);
				field.Name = text;
			}

			// Token: 0x060000D3 RID: 211 RVA: 0x0000F564 File Offset: 0x0000D764
			private static string GenerateString()
			{
				string text = "";
				for (int i = 0; i < 3; i++)
				{
					text += ((char)renamer_v3.RenamerPhase.random.Next(8000, 8500)).ToString();
				}
				return text;
			}

			// Token: 0x04000065 RID: 101
			private static Dictionary<TypeDef, bool> typeRename = new Dictionary<TypeDef, bool>();

			// Token: 0x04000066 RID: 102
			private static List<string> typeNewName = new List<string>();

			// Token: 0x04000067 RID: 103
			private static Dictionary<MethodDef, bool> methodRename = new Dictionary<MethodDef, bool>();

			// Token: 0x04000068 RID: 104
			private static List<string> methodNewName = new List<string>();

			// Token: 0x04000069 RID: 105
			private static Dictionary<FieldDef, bool> fieldRename = new Dictionary<FieldDef, bool>();

			// Token: 0x0400006A RID: 106
			private static List<string> fieldNewName = new List<string>();

			// Token: 0x0400006B RID: 107
			public static bool IsObfuscationActive = true;

			// Token: 0x0400006C RID: 108
			private static Random random = new Random();
		}
	}
}
