using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AtomicVM.Calli;
using AtomicVM.Virtualization;
using AtomicVM.Virtualization.Value_Virt;
using Blink_Obfuscator_1._0;
using Blink_Obfuscator_1._0.Protections;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace AtomicProtector9._0
{
	// Token: 0x0200003A RID: 58
	public partial class Form2 : MetroForm
	{
		// Token: 0x060000FB RID: 251 RVA: 0x000023F1 File Offset: 0x000005F1
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00014A9C File Offset: 0x00012C9C
		private void Form2_Load(object sender, EventArgs e)
		{
			bool flag = File.Exists("C:\\ProgramData\\atomicconfig.txt");
			if (flag)
			{
				FileInfo fileInfo = new FileInfo("C:\\ProgramData\\atomicconfig.txt");
				DateTime lastWriteTime = fileInfo.LastWriteTime;
				this.metroLabel1.Text = "Last saved " + lastWriteTime.ToString();
				string text = File.ReadAllText("C:\\ProgramData\\atomicconfig.txt");
				bool flag2 = text.Contains("Constants");
				if (flag2)
				{
					this.metroCheckBox1.Checked = true;
				}
				bool flag3 = text.Contains("mutation");
				if (flag3)
				{
					this.metroCheckBox2.Checked = true;
				}
				bool flag4 = text.Contains("renamer");
				if (flag4)
				{
					this.metroCheckBox3.Checked = true;
				}
				bool flag5 = text.Contains("cflow");
				if (flag5)
				{
					this.metroCheckBox4.Checked = true;
				}
				bool flag6 = text.Contains("stringenc");
				if (flag6)
				{
					this.metroCheckBox5.Checked = true;
				}
				bool flag7 = text.Contains("distantconstant");
				if (flag7)
				{
					this.metroCheckBox6.Checked = true;
				}
				bool flag8 = text.Contains("refproxy");
				if (flag8)
				{
					this.metroCheckBox7.Checked = true;
				}
				bool flag9 = text.Contains("localtofield");
				if (flag9)
				{
					this.metroCheckBox8.Checked = true;
				}
				bool flag10 = text.Contains("sizeof");
				if (flag10)
				{
					this.metroCheckBox9.Checked = true;
				}
				bool flag11 = text.Contains("stackunderflow");
				if (flag11)
				{
					this.metroCheckBox10.Checked = true;
				}
				bool flag12 = text.Contains("fakewatermark");
				if (flag12)
				{
					this.metroCheckBox11.Checked = true;
				}
				bool flag13 = text.Contains("hideallmethods");
				if (flag13)
				{
					this.metroCheckBox12.Checked = true;
				}
				bool flag14 = text.Contains("strongvirt");
				if (flag14)
				{
					this.metroCheckBox13.Checked = true;
				}
				bool flag15 = text.Contains("antidfour");
				if (flag15)
				{
					this.metroCheckBox16.Checked = true;
				}
				bool flag16 = text.Contains("antiildasmr");
				if (flag16)
				{
					this.metroCheckBox17.Checked = true;
				}
				bool flag17 = text.Contains("antidump");
				if (flag17)
				{
					this.metroCheckBox18.Checked = true;
				}
				bool flag18 = text.Contains("antivm");
				if (flag18)
				{
					this.metroCheckBox19.Checked = true;
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00014D18 File Offset: 0x00012F18
		private void metroButton1_Click(object sender, EventArgs e)
		{
			this.metroLabel1.Text = "Status: Updating..";
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			string text11 = "";
			string text12 = "";
			string text13 = "";
			string text14 = "";
			string text15 = "";
			string text16 = "";
			string text17 = "";
			string text18 = "";
			bool @checked = this.metroCheckBox1.Checked;
			if (@checked)
			{
				text = "Constants";
			}
			bool checked2 = this.metroCheckBox2.Checked;
			if (checked2)
			{
				text2 = "mutation";
			}
			bool checked3 = this.metroCheckBox3.Checked;
			if (checked3)
			{
				text3 = "renamer";
			}
			bool checked4 = this.metroCheckBox4.Checked;
			if (checked4)
			{
				text4 = "cflow";
			}
			bool checked5 = this.metroCheckBox5.Checked;
			if (checked5)
			{
				text5 = "stringenc";
			}
			bool checked6 = this.metroCheckBox6.Checked;
			if (checked6)
			{
				text6 = "distantconstant";
			}
			bool checked7 = this.metroCheckBox7.Checked;
			if (checked7)
			{
				text7 = "refproxy";
			}
			bool checked8 = this.metroCheckBox8.Checked;
			if (checked8)
			{
				text8 = "localtofield";
			}
			bool checked9 = this.metroCheckBox9.Checked;
			if (checked9)
			{
				text9 = "sizeof";
			}
			bool checked10 = this.metroCheckBox10.Checked;
			if (checked10)
			{
				text10 = "stackunderflow";
			}
			bool checked11 = this.metroCheckBox11.Checked;
			if (checked11)
			{
				text11 = "fakewatermark";
			}
			bool checked12 = this.metroCheckBox12.Checked;
			if (checked12)
			{
				text12 = "hideallmethods";
			}
			bool checked13 = this.metroCheckBox13.Checked;
			if (checked13)
			{
				text14 = "strongvirt";
			}
			bool checked14 = this.metroCheckBox16.Checked;
			if (checked14)
			{
				text15 = "antidfour";
			}
			bool checked15 = this.metroCheckBox17.Checked;
			if (checked15)
			{
				text16 = "antiildasmr";
			}
			bool checked16 = this.metroCheckBox18.Checked;
			if (checked16)
			{
				text17 = "antidump";
			}
			bool checked17 = this.metroCheckBox19.Checked;
			if (checked17)
			{
				text18 = "antivm";
			}
			string[] contents = new string[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6,
				text7,
				text8,
				text9,
				text10,
				text11,
				text12,
				text13,
				text14,
				text15,
				text16,
				text17,
				text18
			};
			File.WriteAllLines("C:\\ProgramData\\atomicconfig.txt", contents);
			FileInfo fileInfo = new FileInfo("C:\\ProgramData\\atomicconfig.txt");
			DateTime lastWriteTime = fileInfo.LastWriteTime;
			this.metroLabel1.Text = "Last saved " + lastWriteTime.ToString();
			MessageBox.Show("Saved Settings!", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00015024 File Offset: 0x00013224
		private void metroButton2_Click(object sender, EventArgs e)
		{
			ModuleDef moduleDef = ModuleDefMD.Load(this.metroTextBox1.Text);
			bool numberToString = Settings.NumberToString;
			if (numberToString)
			{
				Constants__numbers_.ObfuscateNumbers(moduleDef);
			}
			bool stackUnderflow = Settings.StackUnderflow;
			if (stackUnderflow)
			{
				Stack_Underflow.StackUnderflow(moduleDef);
			}
			bool sizeOf = Settings.SizeOf;
			if (sizeOf)
			{
				SizeOf.Sizeof(moduleDef);
			}
			bool disConstants = Settings.DisConstants;
			if (disConstants)
			{
				Distant_Constants.DisConstants(moduleDef);
			}
			bool refProxy = Settings.RefProxy;
			if (refProxy)
			{
				Method_Wiper.Execute(moduleDef);
			}
			bool constants = Settings.Constants;
			if (constants)
			{
				Constants__numbers_.Inject(moduleDef);
			}
			bool localToFields = Settings.LocalToFields;
			if (localToFields)
			{
				LocalToFields.Protect(moduleDef);
			}
			bool renamer = Settings.Renamer;
			if (renamer)
			{
				Renamer.Execute(moduleDef);
			}
			bool controlFlow = Settings.ControlFlow;
			if (controlFlow)
			{
				Control_Flow.Encrypt(moduleDef);
				Constants__numbers_.Execute(moduleDef);
			}
			bool constant_Mutation = Settings.Constant_Mutation;
			if (constant_Mutation)
			{
				Constant_Mutation.Execute(moduleDef);
			}
			bool antiDe4dot = Settings.AntiDe4dot;
			if (antiDe4dot)
			{
				Anti_De4dot.RemoveDe4dot(moduleDef);
			}
			bool antiILdasm = Settings.AntiILdasm;
			if (antiILdasm)
			{
				Anti_ILDasm.Anti(moduleDef);
			}
			bool koiVMFakeSig = Settings.KoiVMFakeSig;
			if (koiVMFakeSig)
			{
				KoiVM_Fake_Watermark.Execute(moduleDef);
			}
			bool antiDump = Settings.AntiDump;
			if (antiDump)
			{
				AntiDump.Inject(moduleDef);
			}
			bool invalidMetadata = Settings.InvalidMetadata;
			if (invalidMetadata)
			{
				Invalid_Metadata.InvalidMD(moduleDef);
			}
			bool calli = Settings.Calli;
			if (calli)
			{
				Calli.Execute(moduleDef);
			}
			bool antiHTTPDebugger = Settings.AntiHTTPDebugger;
			if (antiHTTPDebugger)
			{
				Anti_Http_Debugger.Execute(moduleDef);
			}
			bool antiFiddler = Settings.AntiFiddler;
			if (antiFiddler)
			{
				Anti_Fiddler.Execute(moduleDef);
			}
			bool stringEncryption = Settings.StringEncryption;
			if (stringEncryption)
			{
				String_Encryption.Inject(moduleDef);
			}
			Watermark.Execute(moduleDef);
			ModuleDef manifestModule = moduleDef.Assembly.ManifestModule;
			moduleDef.EntryPoint.Name = "BlinkRE";
			moduleDef.Mvid = new Guid?(Guid.NewGuid());
			bool strong = Settings.Strong;
			if (strong)
			{
				Protection.Protect(moduleDef);
				Inject.ProtectValue(moduleDef);
				Inject.DoubleProtect(moduleDef);
				Inject.Triple(moduleDef);
				Inject.Triple(moduleDef);
				Method_Wiper.Execute(moduleDef);
				Assembly.MarkAssembly(moduleDef);
				Locals.Protect(moduleDef);
			}
			Directory.CreateDirectory(".\\AtomicProtected");
			moduleDef.Write(".\\AtomicProtected\\" + Path.GetFileName(this.metroTextBox1.Text), new ModuleWriterOptions(moduleDef)
			{
				PEHeadersOptions = 
				{
					NumberOfRvaAndSizes = new uint?(13U)
				},
				MetaDataOptions = 
				{
					TablesHeapOptions = 
					{
						ExtraData = new uint?(4919U)
					}
				},
				Logger = DummyLogger.NoThrowInstance
			});
			Process.Start(".\\AtomicProtected");
			MessageBox.Show("Obfuscation complete! Restart to obfuscate again");
			Environment.Exit(0);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000152C8 File Offset: 0x000134C8
		private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Constants = !Settings.Constants;
			bool @checked = this.metroCheckBox1.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00015320 File Offset: 0x00013520
		private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Constant_Mutation = !Settings.Constant_Mutation;
			bool @checked = this.metroCheckBox2.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00015378 File Offset: 0x00013578
		private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Renamer = !Settings.Renamer;
			bool @checked = this.metroCheckBox3.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000153D0 File Offset: 0x000135D0
		private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ControlFlow = !Settings.ControlFlow;
			bool @checked = this.metroCheckBox4.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00015428 File Offset: 0x00013628
		private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
		{
			Settings.StringEncryption = !Settings.StringEncryption;
			bool @checked = this.metroCheckBox5.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00015480 File Offset: 0x00013680
		private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
		{
			Settings.DisConstants = !Settings.DisConstants;
			bool @checked = this.metroCheckBox6.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000154D8 File Offset: 0x000136D8
		private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
		{
			Settings.RefProxy = !Settings.RefProxy;
			bool @checked = this.metroCheckBox7.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00015530 File Offset: 0x00013730
		private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
		{
			Settings.LocalToFields = !Settings.LocalToFields;
			bool @checked = this.metroCheckBox8.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00015588 File Offset: 0x00013788
		private void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
		{
			Settings.SizeOf = !Settings.SizeOf;
			bool @checked = this.metroCheckBox9.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000155E0 File Offset: 0x000137E0
		private void metroCheckBox10_CheckedChanged(object sender, EventArgs e)
		{
			Settings.StackUnderflow = !Settings.StackUnderflow;
			bool @checked = this.metroCheckBox10.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00015638 File Offset: 0x00013838
		private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)
		{
			Settings.KoiVMFakeSig = !Settings.KoiVMFakeSig;
			bool @checked = this.metroCheckBox11.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00015690 File Offset: 0x00013890
		private void metroCheckBox12_CheckedChanged(object sender, EventArgs e)
		{
			Settings.InvalidMetadata = !Settings.InvalidMetadata;
			bool @checked = this.metroCheckBox12.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000156E8 File Offset: 0x000138E8
		private void metroCheckBox13_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Strong = !Settings.Strong;
			bool @checked = this.metroCheckBox13.Checked;
			if (@checked)
			{
				this.metroCheckBox1.Enabled = false;
				this.metroCheckBox2.Enabled = false;
				this.metroCheckBox3.Enabled = false;
				this.metroCheckBox4.Enabled = false;
				this.metroCheckBox5.Enabled = false;
				this.metroCheckBox6.Enabled = false;
				this.metroCheckBox7.Enabled = false;
				this.metroCheckBox8.Enabled = false;
				this.metroCheckBox9.Enabled = false;
				this.metroCheckBox10.Enabled = false;
				this.metroCheckBox11.Enabled = false;
				this.metroCheckBox12.Enabled = false;
				this.metroCheckBox16.Enabled = false;
				this.metroCheckBox17.Enabled = false;
				this.metroCheckBox18.Enabled = false;
				this.metroCheckBox19.Enabled = false;
				this.metroCheckBox1.Checked = false;
				this.metroCheckBox2.Checked = false;
				this.metroCheckBox3.Checked = false;
				this.metroCheckBox4.Checked = false;
				this.metroCheckBox5.Checked = false;
				this.metroCheckBox6.Checked = false;
				this.metroCheckBox7.Checked = false;
				this.metroCheckBox8.Checked = false;
				this.metroCheckBox9.Checked = false;
				this.metroCheckBox10.Checked = false;
				this.metroCheckBox11.Checked = false;
				this.metroCheckBox12.Checked = false;
				this.metroCheckBox16.Checked = false;
				this.metroCheckBox17.Checked = false;
				this.metroCheckBox18.Checked = false;
				this.metroCheckBox19.Checked = false;
			}
			else
			{
				this.metroCheckBox1.Enabled = true;
				this.metroCheckBox2.Enabled = true;
				this.metroCheckBox3.Enabled = true;
				this.metroCheckBox4.Enabled = true;
				this.metroCheckBox5.Enabled = true;
				this.metroCheckBox6.Enabled = true;
				this.metroCheckBox7.Enabled = true;
				this.metroCheckBox8.Enabled = true;
				this.metroCheckBox9.Enabled = true;
				this.metroCheckBox10.Enabled = true;
				this.metroCheckBox11.Enabled = true;
				this.metroCheckBox12.Enabled = true;
				this.metroCheckBox16.Enabled = true;
				this.metroCheckBox17.Enabled = true;
				this.metroCheckBox18.Enabled = true;
				this.metroCheckBox19.Enabled = true;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00015990 File Offset: 0x00013B90
		private void metroCheckBox16_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AntiDe4dot = !Settings.AntiDe4dot;
			bool @checked = this.metroCheckBox16.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000159E8 File Offset: 0x00013BE8
		private void metroCheckBox17_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AntiILdasm = !Settings.AntiILdasm;
			bool @checked = this.metroCheckBox17.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00015A40 File Offset: 0x00013C40
		private void metroCheckBox18_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AntiDump = !Settings.AntiDump;
			bool @checked = this.metroCheckBox18.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00015A98 File Offset: 0x00013C98
		private void metroCheckBox19_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AntiHTTPDebugger = !Settings.AntiHTTPDebugger;
			bool @checked = this.metroCheckBox19.Checked;
			if (@checked)
			{
				this.metroCheckBox13.Enabled = false;
				this.metroCheckBox13.Checked = false;
			}
			else
			{
				this.metroCheckBox13.Enabled = true;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00015AF0 File Offset: 0x00013CF0
		private void metroCheckBox14_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.metroCheckBox14.Checked;
			if (@checked)
			{
				this.metroCheckBox1.Checked = true;
				this.metroCheckBox2.Checked = true;
				this.metroCheckBox3.Checked = true;
				this.metroCheckBox4.Checked = true;
				this.metroCheckBox5.Checked = true;
				this.metroCheckBox6.Checked = true;
				this.metroCheckBox7.Checked = true;
				this.metroCheckBox8.Checked = true;
				this.metroCheckBox9.Checked = true;
				this.metroCheckBox10.Checked = true;
				this.metroCheckBox11.Checked = true;
				this.metroCheckBox12.Checked = true;
				this.metroCheckBox16.Checked = true;
				this.metroCheckBox17.Checked = true;
				this.metroCheckBox18.Checked = true;
				this.metroCheckBox19.Checked = true;
			}
			else
			{
				this.metroCheckBox1.Checked = false;
				this.metroCheckBox2.Checked = false;
				this.metroCheckBox3.Checked = false;
				this.metroCheckBox4.Checked = false;
				this.metroCheckBox5.Checked = false;
				this.metroCheckBox6.Checked = false;
				this.metroCheckBox7.Checked = false;
				this.metroCheckBox8.Checked = false;
				this.metroCheckBox9.Checked = false;
				this.metroCheckBox10.Checked = false;
				this.metroCheckBox11.Checked = false;
				this.metroCheckBox12.Checked = false;
				this.metroCheckBox16.Checked = false;
				this.metroCheckBox17.Checked = false;
				this.metroCheckBox18.Checked = false;
				this.metroCheckBox19.Checked = false;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00015CBC File Offset: 0x00013EBC
		private void metroCheckBox15_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.metroCheckBox15.Checked;
			if (@checked)
			{
				this.metroCheckBox1.Checked = false;
				this.metroCheckBox2.Checked = false;
				this.metroCheckBox3.Checked = false;
				this.metroCheckBox4.Checked = false;
				this.metroCheckBox5.Checked = false;
				this.metroCheckBox6.Checked = false;
				this.metroCheckBox7.Checked = false;
				this.metroCheckBox8.Checked = false;
				this.metroCheckBox9.Checked = false;
				this.metroCheckBox10.Checked = false;
				this.metroCheckBox11.Checked = false;
				this.metroCheckBox12.Checked = false;
				this.metroCheckBox13.Checked = false;
				this.metroCheckBox16.Checked = false;
				this.metroCheckBox17.Checked = false;
				this.metroCheckBox18.Checked = false;
				this.metroCheckBox19.Checked = false;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00015DC0 File Offset: 0x00013FC0
		private void metroTextBox1_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				bool flag = array != null;
				bool flag2 = flag;
				if (flag2)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					bool flag3 = num != -1;
					bool flag4 = flag3;
					if (flag4)
					{
						string a = text.Substring(num).ToLower();
						bool flag5 = a == ".exe" || a == ".dll";
						bool flag6 = flag5;
						if (flag6)
						{
							base.Activate();
							this.metroTextBox1.Text = text;
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00015E84 File Offset: 0x00014084
		private void metroTextBox1_DragEnter(object sender, DragEventArgs e)
		{
			bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
			bool flag = dataPresent;
			if (flag)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002409 File Offset: 0x00000609
		private void metroLabel6_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/Bwk5c8R");
		}
	}
}
