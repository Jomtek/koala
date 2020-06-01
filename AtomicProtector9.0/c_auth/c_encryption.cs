using System;
using System.IO;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace c_auth
{
	// Token: 0x02000041 RID: 65
	public class c_encryption
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00018858 File Offset: 0x00016A58
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000188A4 File Offset: 0x00016AA4
		public static byte[] str_to_byte_arr(string hex)
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000188F0 File Offset: 0x00016AF0
		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform cryptoTransform = aes.CreateEncryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						byte[] bytes = Encoding.UTF8.GetBytes(plainText);
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.FlushFinalBlock();
						byte[] ba = memoryStream.ToArray();
						result = c_encryption.byte_arr_to_str(ba);
					}
				}
			}
			return result;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000189B8 File Offset: 0x00016BB8
		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string @string;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform cryptoTransform = aes.CreateDecryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						byte[] array = c_encryption.str_to_byte_arr(cipherText);
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.FlushFinalBlock();
						byte[] array2 = memoryStream.ToArray();
						@string = Encoding.UTF8.GetString(array2, 0, array2.Length);
					}
				}
			}
			return @string;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00018A84 File Offset: 0x00016C84
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00002509 File Offset: 0x00000709
		public static string sha256(string randomString)
		{
			return c_encryption.byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(randomString)));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00018AC8 File Offset: 0x00016CC8
		public static string encrypt(string message, string enc_key, [Optional] string iv)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(c_encryption.sha256(enc_key).Substring(0, 32));
			bool flag = iv == "default_iv";
			string result;
			if (flag)
			{
				result = c_encryption.EncryptString(message, bytes, Encoding.UTF8.GetBytes("1514834626578394"));
			}
			else
			{
				result = c_encryption.EncryptString(message, bytes, Encoding.UTF8.GetBytes(c_encryption.sha256(iv).Substring(0, 16)));
			}
			return result;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00018B3C File Offset: 0x00016D3C
		public static string decrypt(string message, string enc_key, [Optional] string iv)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(c_encryption.sha256(enc_key).Substring(0, 32));
			bool flag = iv == "default_iv";
			string result;
			if (flag)
			{
				result = c_encryption.DecryptString(message, bytes, Encoding.UTF8.GetBytes("1514834626578394"));
			}
			else
			{
				result = c_encryption.DecryptString(message, bytes, Encoding.UTF8.GetBytes(c_encryption.sha256(iv).Substring(0, 16)));
			}
			return result;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00018BB0 File Offset: 0x00016DB0
		public static DateTime unix_to_date(double unixTimeStamp)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00018BE0 File Offset: 0x00016DE0
		public static bool pin_public_key(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool flag = certificate == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string publicKeyString = certificate.GetPublicKeyString();
				bool flag2 = publicKeyString.Equals("3082010A0282010100C7429D4B4591E50FE4B3ABDA72DB3F3EA578E12B9CD4E228E4EDFAC3F9681F354C913386A13E88181D1B14D91723FB50770C5DC94FCA59D4DEE4F6632041EFE76C3B6BCFF6B8F5B38AF92547D04BD08AF71087B094F5DFE8760C8CD09A3771836807588B02282BEC7C4CD73EE7C650C0A7C7F36F2FA56DA17E892B2760C4C75950EA5C90CD4EA301EC0CBC36B8372FE8515A7131CC6DF13A97D95B94C6A92AC4E5BFF217FCB20B3C01DB085229E919555D426D919E9A9F0D4C599FE7473FA7DBDE9B33279E2FC29F6CE09FA1269409E4A82175C8E0B65723DB6F856A53E3FD11363ADD63D1346790A3E4D1E454D1714ECED9815A0F85C5019C0D4DC3D58234C10203010001");
				result = flag2;
			}
			return result;
		}
	}
}
