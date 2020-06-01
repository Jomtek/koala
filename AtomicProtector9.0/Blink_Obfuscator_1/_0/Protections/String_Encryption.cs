using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Blink_Obfuscator_1._0.Runtime;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000036 RID: 54
	internal class String_Encryption
	{
		// Token: 0x060000EA RID: 234 RVA: 0x00013FC8 File Offset: 0x000121C8
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(String_Encryption).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(String_Encryption).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			String_Encryption.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Decrypt");
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

		// Token: 0x060000EB RID: 235 RVA: 0x000140B0 File Offset: 0x000122B0
		public static string Encrypt(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			byte[] bytes2 = new Rfc2898DeriveBytes(String_Encryption.PasswordHash, Encoding.ASCII.GetBytes(String_Encryption.SaltKey)).GetBytes(32);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.Zeros
			};
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(String_Encryption.VIKey));
			byte[] inArray;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					inArray = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000141A4 File Offset: 0x000123A4
		public static void Inject(ModuleDef module)
		{
			String_Encryption.InjectClass(module);
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
								bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									string plainText = instructions[i].Operand as string;
									string operand = String_Encryption.Encrypt(plainText);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, String_Encryption.init));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000073 RID: 115
		public static Random random = new Random();

		// Token: 0x04000074 RID: 116
		private static IMethod _decrypt;

		// Token: 0x04000075 RID: 117
		private static ModuleDef _mod;

		// Token: 0x04000076 RID: 118
		public static MethodDef init;

		// Token: 0x04000077 RID: 119
		private static readonly string PasswordHash = "P@@$Sw0rd";

		// Token: 0x04000078 RID: 120
		private static readonly string SaltKey = "S@L$%^#T&&$%*%^$^#$KEY";

		// Token: 0x04000079 RID: 121
		private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
	}
}
