using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using c_auth;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace AtomicProtector9._0
{
	// Token: 0x02000039 RID: 57
	public partial class Form1 : MetroForm
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x000023D7 File Offset: 0x000005D7
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000023EF File Offset: 0x000005EF
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000143D0 File Offset: 0x000125D0
		private void metroButton1_Click(object sender, EventArgs e)
		{
			bool flag = c_api.c_all_in_one(this.metroTextBox1.Text, "default");
			bool flag2 = flag;
			if (flag2)
			{
				File.WriteAllText("C:\\ProgramData\\atomicprotectorkeysave.txt", this.metroTextBox1.Text);
				Form2 form = new Form2();
				form.ShowDialog();
				base.Close();
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00014428 File Offset: 0x00012628
		private void metroLink1_Click(object sender, EventArgs e)
		{
			WebClient webClient = new WebClient();
			Process.Start("https://discord.gg/Bwk5c8R");
		}
	}
}
