using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Blink_Obfuscator_1._0.Runtime
{
	// Token: 0x02000007 RID: 7
	internal class Fiddler
	{
		// Token: 0x0600000F RID: 15
		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int MessageBox(IntPtr h, string m, string c, int type);

		// Token: 0x06000010 RID: 16 RVA: 0x000020DE File Offset: 0x000002DE
		private static void Init()
		{
			Fiddler.Invoke();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020E7 File Offset: 0x000002E7
		private static void Invoke()
		{
			Fiddler.Read();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000347C File Offset: 0x0000167C
		private static void Closeprogram()
		{
			string location = Assembly.GetExecutingAssembly().Location;
			Process.Start(new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" + location + "\"")
			{
				WindowStyle = ProcessWindowStyle.Hidden
			}).Dispose();
			Environment.Exit(0);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000034CC File Offset: 0x000016CC
		private static void Read()
		{
			Process[] processesByName = Process.GetProcessesByName("Fiddler");
			bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Programs\\Fiddler\\App.ico");
			if (flag)
			{
				Fiddler.MessageBox((IntPtr)0, "Fiddler has been detected on ur computer, the program will be deleted from ur computer...", "Blink Obfuscator", 0);
				Fiddler.Closeprogram();
			}
			else
			{
				bool flag2 = processesByName.Length != 0;
				if (flag2)
				{
					Fiddler.MessageBox((IntPtr)0, "Fiddler process is opened, the program will be deleted from ur computer...", "Blink Obfuscator", 0);
					Fiddler.Closeprogram();
				}
			}
		}
	}
}
