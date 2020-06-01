using System;

namespace Blink_Obfuscator_1._0.Runtime
{
	// Token: 0x02000009 RID: 9
	internal class String_Encryption_Virt
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00003824 File Offset: 0x00001A24
		public static string LoadData(string plainText, uint data1)
		{
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			data1 *= 100U;
			bool flag = data1 != uint.MaxValue;
			string result;
			if (flag)
			{
				plainText = plainText.Replace(" 69 ", "q");
				plainText = plainText.Replace(" 70 ", "w");
				data1 *= 100U;
				plainText = plainText.Replace(" 71 ", "e");
				plainText = plainText.Replace(" 72 ", "r");
				data1 *= 100U;
				plainText = plainText.Replace(" 73 ", "t");
				plainText = plainText.Replace(" 74 ", "y");
				plainText = plainText.Replace(" 75 ", "u");
				plainText = plainText.Replace(" 76 ", "i");
				data1 *= 100U;
				plainText = plainText.Replace(" 77 ", "o");
				plainText = plainText.Replace(" 78 ", "p");
				plainText = plainText.Replace(" 79 ", "a");
				plainText = plainText.Replace(" 80 ", "s");
				data1 *= 100U;
				plainText = plainText.Replace(" 81 ", "d");
				plainText = plainText.Replace(" 82 ", "f");
				plainText = plainText.Replace(" 83 ", "g");
				data1 *= 100U;
				plainText = plainText.Replace(" 84 ", "h");
				plainText = plainText.Replace(" 85 ", "j");
				plainText = plainText.Replace(" 86 ", "k");
				plainText = plainText.Replace(" 87 ", "l");
				data1 *= 100U;
				plainText = plainText.Replace(" 88 ", "z");
				plainText = plainText.Replace(" 89 ", "x");
				plainText = plainText.Replace(" 90 ", "c");
				plainText = plainText.Replace(" 91 ", "v");
				data1 *= 100U;
				plainText = plainText.Replace(" 92 ", "b");
				data1 *= 100U;
				plainText = plainText.Replace(" 93 ", "n");
				plainText = plainText.Replace(" 94 ", "m");
				result = plainText;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0400002B RID: 43
		private static readonly string PasswordHash = "P@@$#Sw0rd";

		// Token: 0x0400002C RID: 44
		private static readonly string SaltKey = "S@L$%^#T&*&@#&$%*%^$^#$KEY";

		// Token: 0x0400002D RID: 45
		private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
	}
}
