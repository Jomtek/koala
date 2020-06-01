using System;
using System.Windows.Forms;

namespace AtomicProtector9._0
{
	// Token: 0x0200003B RID: 59
	internal static class Program
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00002417 File Offset: 0x00000617
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form2());
		}
	}
}
