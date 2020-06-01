using System;

namespace c_auth
{
	// Token: 0x02000040 RID: 64
	public class c_userdata
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600013A RID: 314 RVA: 0x000024CD File Offset: 0x000006CD
		// (set) Token: 0x0600013B RID: 315 RVA: 0x000024D4 File Offset: 0x000006D4
		public static string username { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600013C RID: 316 RVA: 0x000024DC File Offset: 0x000006DC
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000024E3 File Offset: 0x000006E3
		public static string email { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600013E RID: 318 RVA: 0x000024EB File Offset: 0x000006EB
		// (set) Token: 0x0600013F RID: 319 RVA: 0x000024F2 File Offset: 0x000006F2
		public static DateTime expires { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000140 RID: 320 RVA: 0x000024FA File Offset: 0x000006FA
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00002501 File Offset: 0x00000701
		public static int rank
		{
			get
			{
				return c_userdata.<rank>k__BackingField;
			}
			set
			{
				c_userdata.<rank>k__BackingField = value;
			}
		}
	}
}
