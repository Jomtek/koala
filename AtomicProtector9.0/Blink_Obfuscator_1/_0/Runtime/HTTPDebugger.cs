using System;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Blink_Obfuscator_1._0.Runtime
{
	// Token: 0x02000008 RID: 8
	internal class HTTPDebugger
	{
		// Token: 0x06000015 RID: 21
		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int MessageBox(IntPtr h, string m, string c, int type);

		// Token: 0x06000016 RID: 22 RVA: 0x000020F0 File Offset: 0x000002F0
		private static void Init()
		{
			HTTPDebugger.Invoke();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000020F9 File Offset: 0x000002F9
		private static void Invoke()
		{
			HTTPDebugger.Read();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000347C File Offset: 0x0000167C
		private static void Closeprogram()
		{
			string location = Assembly.GetExecutingAssembly().Location;
			Process.Start(new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" + location + "\"")
			{
				WindowStyle = ProcessWindowStyle.Hidden
			}).Dispose();
			Environment.Exit(0);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003548 File Offset: 0x00001748
		private static void Read()
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						bool flag = (managementBaseObject["Manufacturer"].ToString().ToLower() == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || managementBaseObject["Manufacturer"].ToString().ToLower().Contains("vmware") || managementBaseObject["Model"].ToString() == "VirtualBox";
						if (flag)
						{
							HTTPDebugger.MessageBox((IntPtr)0, "This computer is a VM (VirtualMachine), you cannot run on here. the program will be deleted from ur computer...", "AtomicProtector", 0);
							HTTPDebugger.Closeprogram();
							return;
						}
					}
				}
			}
			foreach (ManagementBaseObject managementBaseObject2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
			{
				bool flag2 = managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VMware") && managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VBox");
				if (flag2)
				{
					HTTPDebugger.MessageBox((IntPtr)0, "This computer is a VM (VirtualMachine), you cannot run on here. the program will be deleted from ur computer...", "AtomicProtector", 0);
					HTTPDebugger.Closeprogram();
					return;
				}
			}
			long num = (long)Environment.TickCount;
			Thread.Sleep(500);
			long num2 = (long)Environment.TickCount;
			bool flag3 = num2 - num < 500L;
			if (flag3)
			{
				HTTPDebugger.MessageBox((IntPtr)0, "This computer is a VM (VirtualMachine), you cannot run on here. the program will be deleted from ur computer...", "AtomicProtector", 0);
				HTTPDebugger.Closeprogram();
			}
			else
			{
				int num3 = new Random().Next(3000, 10000);
				DateTime now = DateTime.Now;
				Thread.Sleep(num3);
				bool flag4 = (DateTime.Now - now).TotalMilliseconds < (double)num3;
				if (flag4)
				{
					HTTPDebugger.MessageBox((IntPtr)0, "This computer is a VM (VirtualMachine), you cannot run on here. the program will be deleted from ur computer...", "AtomicProtector", 0);
					HTTPDebugger.Closeprogram();
				}
			}
		}
	}
}
