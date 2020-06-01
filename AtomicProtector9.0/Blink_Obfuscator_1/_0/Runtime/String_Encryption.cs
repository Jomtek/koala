using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Blink_Obfuscator_1._0.Runtime
{
	// Token: 0x0200000A RID: 10
	internal class String_Encryption
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00003A9C File Offset: 0x00001C9C
		public static string Decrypt(string encryptedText)
		{
			byte[] array = Convert.FromBase64String(encryptedText);
			byte[] bytes = new Rfc2898DeriveBytes(String_Encryption.PasswordHash, Encoding.ASCII.GetBytes(String_Encryption.SaltKey)).GetBytes(32);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.None
			};
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, Encoding.ASCII.GetBytes(String_Encryption.VIKey));
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array2 = new byte[array.Length];
			int count = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array2, 0, count).TrimEnd("\0".ToCharArray());
		}

		// Token: 0x0400002E RID: 46
		private static readonly string PasswordHash = "P@@$Sw0rd";

		// Token: 0x0400002F RID: 47
		private static readonly string SaltKey = "S@L$%^#T&&$%*%^$^#$KEY";

		// Token: 0x04000030 RID: 48
		private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
	}
}
