using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Blink_Obfuscator_1._0.Protections;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicVM.Virtualization.Value_Virt
{
	// Token: 0x02000049 RID: 73
	internal class Inject
	{
		// Token: 0x06000168 RID: 360 RVA: 0x00019BA0 File Offset: 0x00017DA0
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			Inject.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "VirtualizeValue");
			Inject.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Double");
			Inject.init2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "OnlyString");
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

		// Token: 0x06000169 RID: 361 RVA: 0x00019CE4 File Offset: 0x00017EE4
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwrtyuiopasdfghjklzxcvbnm,1234567890", length)
			select s[Inject.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00019D30 File Offset: 0x00017F30
		public static string EncryptString(string plainText, string passPhrase)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Inject.initVector);
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, null);
			byte[] bytes3 = passwordDeriveBytes.GetBytes(32);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00019DD4 File Offset: 0x00017FD4
		public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
		{
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			for (int i = 0; i < szPlainText.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)((int)c ^ szEncryptionKey);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00019E30 File Offset: 0x00018030
		public static void ProtectValue(ModuleDef module)
		{
			Inject.InjectClass(module);
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
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldc_I4 || instructions[i].OpCode == OpCodes.Ldc_I4_S;
								if (flag2)
								{
									try
									{
										string s = instructions[i].Operand.ToString();
										instructions[i].OpCode = OpCodes.Nop;
										instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, s));
										instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(int).GetMethod("Parse", new Type[]
										{
											typeof(string)
										}))));
									}
									catch
									{
									}
								}
								bool flag3 = instructions[i].OpCode == OpCodes.Ldc_I4_S;
								bool flag4 = flag3;
								if (flag4)
								{
									string s2 = instructions[i].Operand.ToString();
									instructions[i].OpCode = OpCodes.Nop;
									instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, s2));
									instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(short).GetMethod("Parse", new Type[]
									{
										typeof(string)
									}))));
								}
								else
								{
									bool flag5 = instructions[i].OpCode == OpCodes.Ldc_I8;
									bool flag6 = flag5;
									if (flag6)
									{
										string s3 = instructions[i].Operand.ToString();
										instructions[i].OpCode = OpCodes.Nop;
										instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, s3));
										instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(long).GetMethod("Parse", new Type[]
										{
											typeof(string)
										}))));
									}
									else
									{
										bool flag7 = methodDef.Body.Instructions[i].OpCode == OpCodes.Ldc_R4;
										bool flag8 = flag7;
										if (flag8)
										{
											string s4 = methodDef.Body.Instructions[i].Operand.ToString();
											methodDef.Body.Instructions[i].OpCode = OpCodes.Nop;
											methodDef.Body.Instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, s4));
											methodDef.Body.Instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(float).GetMethod("Parse", new Type[]
											{
												typeof(string)
											}))));
										}
									}
								}
								bool flag9 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag9)
								{
									string plainText = (string)instructions[i].Operand;
									string text = Inject.Random(32);
									Inject.initVector = Inject.Random(16);
									string operand = Inject.EncryptString(plainText, text);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 5, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 10, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 11, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 12, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 13, Instruction.Create(OpCodes.Call, Inject.init));
									i += 13;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0001A4DC File Offset: 0x000186DC
		public static void Triple(ModuleDef module)
		{
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
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									string plainText = (string)instructions[i].Operand;
									string text = Inject.Random(32);
									string operand = Inject.EncryptString(plainText, text);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Inject.init2));
									i += 3;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0001A688 File Offset: 0x00018888
		public static void DoubleProtect(ModuleDef module)
		{
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
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									string plainText = (string)instructions[i].Operand;
									string text = Inject.Random(32);
									Inject.initVector = Inject.Random(16);
									string operand = Inject.EncryptString(plainText, text);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 5, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 10, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 11, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 12, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 13, Instruction.Create(OpCodes.Call, Inject.init));
									i += 13;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040000BE RID: 190
		public static MethodDef init;

		// Token: 0x040000BF RID: 191
		public static MethodDef init1;

		// Token: 0x040000C0 RID: 192
		public static MethodDef init2;

		// Token: 0x040000C1 RID: 193
		public static Random random = new Random();

		// Token: 0x040000C2 RID: 194
		public static string initVector = "pemgail9uzpgzl88";

		// Token: 0x040000C3 RID: 195
		private const int keysize = 256;
	}
}
