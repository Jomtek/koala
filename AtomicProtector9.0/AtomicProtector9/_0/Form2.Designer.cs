namespace AtomicProtector9._0
{
	// Token: 0x0200003A RID: 58
	public partial class Form2 : global::MetroFramework.Forms.MetroForm
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00015EC0 File Offset: 0x000140C0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00015EF8 File Offset: 0x000140F8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AtomicProtector9._0.Form2));
			this.metroCheckBox1 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox2 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox3 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox4 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox5 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox6 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox7 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox8 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox9 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox10 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox11 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox12 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox13 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox14 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox15 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox16 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox17 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox18 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroCheckBox19 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroButton1 = new global::MetroFramework.Controls.MetroButton();
			this.metroLabel1 = new global::MetroFramework.Controls.MetroLabel();
			this.metroTextBox1 = new global::MetroFramework.Controls.MetroTextBox();
			this.metroButton2 = new global::MetroFramework.Controls.MetroButton();
			this.metroLabel2 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new global::MetroFramework.Controls.MetroLabel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.metroLabel7 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLabel6 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new global::MetroFramework.Controls.MetroLabel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Location = new global::System.Drawing.Point(38, 88);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new global::System.Drawing.Size(76, 15);
			this.metroCheckBox1.TabIndex = 0;
			this.metroCheckBox1.Text = "Constants";
			this.metroCheckBox1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox1.UseSelectable = true;
			this.metroCheckBox1.CheckedChanged += new global::System.EventHandler(this.metroCheckBox1_CheckedChanged);
			this.metroCheckBox2.AutoSize = true;
			this.metroCheckBox2.Location = new global::System.Drawing.Point(37, 109);
			this.metroCheckBox2.Name = "metroCheckBox2";
			this.metroCheckBox2.Size = new global::System.Drawing.Size(123, 15);
			this.metroCheckBox2.TabIndex = 1;
			this.metroCheckBox2.Text = "Constant Mutation";
			this.metroCheckBox2.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox2.UseSelectable = true;
			this.metroCheckBox2.CheckedChanged += new global::System.EventHandler(this.metroCheckBox2_CheckedChanged);
			this.metroCheckBox3.AutoSize = true;
			this.metroCheckBox3.Location = new global::System.Drawing.Point(37, 130);
			this.metroCheckBox3.Name = "metroCheckBox3";
			this.metroCheckBox3.Size = new global::System.Drawing.Size(70, 15);
			this.metroCheckBox3.TabIndex = 2;
			this.metroCheckBox3.Text = "Renamer";
			this.metroCheckBox3.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox3.UseSelectable = true;
			this.metroCheckBox3.CheckedChanged += new global::System.EventHandler(this.metroCheckBox3_CheckedChanged);
			this.metroCheckBox4.AutoSize = true;
			this.metroCheckBox4.Location = new global::System.Drawing.Point(37, 148);
			this.metroCheckBox4.Name = "metroCheckBox4";
			this.metroCheckBox4.Size = new global::System.Drawing.Size(91, 15);
			this.metroCheckBox4.TabIndex = 3;
			this.metroCheckBox4.Text = "Control Flow";
			this.metroCheckBox4.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox4.UseSelectable = true;
			this.metroCheckBox4.CheckedChanged += new global::System.EventHandler(this.metroCheckBox4_CheckedChanged);
			this.metroCheckBox5.AutoSize = true;
			this.metroCheckBox5.Location = new global::System.Drawing.Point(37, 169);
			this.metroCheckBox5.Name = "metroCheckBox5";
			this.metroCheckBox5.Size = new global::System.Drawing.Size(114, 15);
			this.metroCheckBox5.TabIndex = 4;
			this.metroCheckBox5.Text = "String Encryption";
			this.metroCheckBox5.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox5.UseSelectable = true;
			this.metroCheckBox5.CheckedChanged += new global::System.EventHandler(this.metroCheckBox5_CheckedChanged);
			this.metroCheckBox6.AutoSize = true;
			this.metroCheckBox6.Location = new global::System.Drawing.Point(37, 190);
			this.metroCheckBox6.Name = "metroCheckBox6";
			this.metroCheckBox6.Size = new global::System.Drawing.Size(116, 15);
			this.metroCheckBox6.TabIndex = 5;
			this.metroCheckBox6.Text = "Distant Constants";
			this.metroCheckBox6.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox6.UseSelectable = true;
			this.metroCheckBox6.CheckedChanged += new global::System.EventHandler(this.metroCheckBox6_CheckedChanged);
			this.metroCheckBox7.AutoSize = true;
			this.metroCheckBox7.Location = new global::System.Drawing.Point(37, 211);
			this.metroCheckBox7.Name = "metroCheckBox7";
			this.metroCheckBox7.Size = new global::System.Drawing.Size(73, 15);
			this.metroCheckBox7.TabIndex = 6;
			this.metroCheckBox7.Text = "Ref Proxy";
			this.metroCheckBox7.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox7.UseSelectable = true;
			this.metroCheckBox7.CheckedChanged += new global::System.EventHandler(this.metroCheckBox7_CheckedChanged);
			this.metroCheckBox8.AutoSize = true;
			this.metroCheckBox8.Location = new global::System.Drawing.Point(37, 232);
			this.metroCheckBox8.Name = "metroCheckBox8";
			this.metroCheckBox8.Size = new global::System.Drawing.Size(99, 15);
			this.metroCheckBox8.TabIndex = 7;
			this.metroCheckBox8.Text = "Local To Fields";
			this.metroCheckBox8.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox8.UseSelectable = true;
			this.metroCheckBox8.CheckedChanged += new global::System.EventHandler(this.metroCheckBox8_CheckedChanged);
			this.metroCheckBox9.AutoSize = true;
			this.metroCheckBox9.Location = new global::System.Drawing.Point(204, 88);
			this.metroCheckBox9.Name = "metroCheckBox9";
			this.metroCheckBox9.Size = new global::System.Drawing.Size(56, 15);
			this.metroCheckBox9.TabIndex = 8;
			this.metroCheckBox9.Text = "SizeOf";
			this.metroCheckBox9.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox9.UseSelectable = true;
			this.metroCheckBox9.CheckedChanged += new global::System.EventHandler(this.metroCheckBox9_CheckedChanged);
			this.metroCheckBox10.AutoSize = true;
			this.metroCheckBox10.Location = new global::System.Drawing.Point(204, 109);
			this.metroCheckBox10.Name = "metroCheckBox10";
			this.metroCheckBox10.Size = new global::System.Drawing.Size(109, 15);
			this.metroCheckBox10.TabIndex = 9;
			this.metroCheckBox10.Text = "Stack Underflow";
			this.metroCheckBox10.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox10.UseSelectable = true;
			this.metroCheckBox10.CheckedChanged += new global::System.EventHandler(this.metroCheckBox10_CheckedChanged);
			this.metroCheckBox11.AutoSize = true;
			this.metroCheckBox11.Location = new global::System.Drawing.Point(204, 130);
			this.metroCheckBox11.Name = "metroCheckBox11";
			this.metroCheckBox11.Size = new global::System.Drawing.Size(108, 15);
			this.metroCheckBox11.TabIndex = 10;
			this.metroCheckBox11.Text = "Fake Watermark";
			this.metroCheckBox11.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox11.UseSelectable = true;
			this.metroCheckBox11.CheckedChanged += new global::System.EventHandler(this.metroCheckBox11_CheckedChanged);
			this.metroCheckBox12.AutoSize = true;
			this.metroCheckBox12.Location = new global::System.Drawing.Point(204, 151);
			this.metroCheckBox12.Name = "metroCheckBox12";
			this.metroCheckBox12.Size = new global::System.Drawing.Size(113, 15);
			this.metroCheckBox12.TabIndex = 11;
			this.metroCheckBox12.Text = "Hide all Methods";
			this.metroCheckBox12.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox12.UseSelectable = true;
			this.metroCheckBox12.CheckedChanged += new global::System.EventHandler(this.metroCheckBox12_CheckedChanged);
			this.metroCheckBox13.AutoSize = true;
			this.metroCheckBox13.Location = new global::System.Drawing.Point(204, 172);
			this.metroCheckBox13.Name = "metroCheckBox13";
			this.metroCheckBox13.Size = new global::System.Drawing.Size(92, 15);
			this.metroCheckBox13.TabIndex = 12;
			this.metroCheckBox13.Text = "Virtualization";
			this.metroCheckBox13.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox13.UseSelectable = true;
			this.metroCheckBox13.CheckedChanged += new global::System.EventHandler(this.metroCheckBox13_CheckedChanged);
			this.metroCheckBox14.AutoSize = true;
			this.metroCheckBox14.Location = new global::System.Drawing.Point(204, 193);
			this.metroCheckBox14.Name = "metroCheckBox14";
			this.metroCheckBox14.Size = new global::System.Drawing.Size(71, 15);
			this.metroCheckBox14.TabIndex = 13;
			this.metroCheckBox14.Text = "Check all";
			this.metroCheckBox14.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox14.UseSelectable = true;
			this.metroCheckBox14.CheckedChanged += new global::System.EventHandler(this.metroCheckBox14_CheckedChanged);
			this.metroCheckBox15.AutoSize = true;
			this.metroCheckBox15.Location = new global::System.Drawing.Point(204, 215);
			this.metroCheckBox15.Name = "metroCheckBox15";
			this.metroCheckBox15.Size = new global::System.Drawing.Size(86, 15);
			this.metroCheckBox15.TabIndex = 14;
			this.metroCheckBox15.Text = "Uncheck All";
			this.metroCheckBox15.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox15.UseSelectable = true;
			this.metroCheckBox15.CheckedChanged += new global::System.EventHandler(this.metroCheckBox15_CheckedChanged);
			this.metroCheckBox16.AutoSize = true;
			this.metroCheckBox16.Location = new global::System.Drawing.Point(373, 88);
			this.metroCheckBox16.Name = "metroCheckBox16";
			this.metroCheckBox16.Size = new global::System.Drawing.Size(88, 15);
			this.metroCheckBox16.TabIndex = 15;
			this.metroCheckBox16.Text = "Anti-De4dot";
			this.metroCheckBox16.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox16.UseSelectable = true;
			this.metroCheckBox16.CheckedChanged += new global::System.EventHandler(this.metroCheckBox16_CheckedChanged);
			this.metroCheckBox17.AutoSize = true;
			this.metroCheckBox17.Location = new global::System.Drawing.Point(484, 88);
			this.metroCheckBox17.Name = "metroCheckBox17";
			this.metroCheckBox17.Size = new global::System.Drawing.Size(86, 15);
			this.metroCheckBox17.TabIndex = 16;
			this.metroCheckBox17.Text = "Anti ILdasm";
			this.metroCheckBox17.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox17.UseSelectable = true;
			this.metroCheckBox17.CheckedChanged += new global::System.EventHandler(this.metroCheckBox17_CheckedChanged);
			this.metroCheckBox18.AutoSize = true;
			this.metroCheckBox18.Location = new global::System.Drawing.Point(373, 130);
			this.metroCheckBox18.Name = "metroCheckBox18";
			this.metroCheckBox18.Size = new global::System.Drawing.Size(81, 15);
			this.metroCheckBox18.TabIndex = 17;
			this.metroCheckBox18.Text = "Anti Dump";
			this.metroCheckBox18.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox18.UseSelectable = true;
			this.metroCheckBox18.CheckedChanged += new global::System.EventHandler(this.metroCheckBox18_CheckedChanged);
			this.metroCheckBox19.AutoSize = true;
			this.metroCheckBox19.Location = new global::System.Drawing.Point(484, 130);
			this.metroCheckBox19.Name = "metroCheckBox19";
			this.metroCheckBox19.Size = new global::System.Drawing.Size(66, 15);
			this.metroCheckBox19.TabIndex = 18;
			this.metroCheckBox19.Text = "Anti VM";
			this.metroCheckBox19.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroCheckBox19.UseSelectable = true;
			this.metroCheckBox19.CheckedChanged += new global::System.EventHandler(this.metroCheckBox19_CheckedChanged);
			this.metroButton1.Location = new global::System.Drawing.Point(400, 172);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new global::System.Drawing.Size(113, 23);
			this.metroButton1.TabIndex = 19;
			this.metroButton1.Text = "Save Settings";
			this.metroButton1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new global::System.EventHandler(this.metroButton1_Click);
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new global::System.Drawing.Point(410, 207);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new global::System.Drawing.Size(91, 19);
			this.metroLabel1.TabIndex = 20;
			this.metroLabel1.Text = "Not Saved Yet";
			this.metroLabel1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroTextBox1.AllowDrop = true;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new global::System.Drawing.Point(242, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new global::System.Drawing.Size(21, 21);
			this.metroTextBox1.CustomButton.Style = global::MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new global::System.Drawing.Point(73, 271);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new global::System.Drawing.Size(264, 23);
			this.metroTextBox1.TabIndex = 21;
			this.metroTextBox1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = global::System.Drawing.Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Pixel);
			this.metroTextBox1.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.metroTextBox1_DragDrop);
			this.metroTextBox1.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.metroTextBox1_DragEnter);
			this.metroButton2.Location = new global::System.Drawing.Point(348, 271);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new global::System.Drawing.Size(113, 23);
			this.metroButton2.TabIndex = 22;
			this.metroButton2.Text = "Obfuscate";
			this.metroButton2.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += new global::System.EventHandler(this.metroButton2_Click);
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new global::System.Drawing.Point(147, 299);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new global::System.Drawing.Size(94, 19);
			this.metroLabel2.TabIndex = 23;
			this.metroLabel2.Text = "Drag File Here";
			this.metroLabel2.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = global::MetroFramework.MetroLabelSize.Tall;
			this.metroLabel3.ForeColor = global::System.Drawing.SystemColors.ControlLightLight;
			this.metroLabel3.Location = new global::System.Drawing.Point(38, 352);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new global::System.Drawing.Size(74, 25);
			this.metroLabel3.TabIndex = 24;
			this.metroLabel3.Text = "Updates";
			this.metroLabel3.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel3.UseCustomForeColor = true;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = global::MetroFramework.MetroLabelSize.Tall;
			this.metroLabel4.ForeColor = global::System.Drawing.SystemColors.ControlLightLight;
			this.metroLabel4.Location = new global::System.Drawing.Point(33, 354);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new global::System.Drawing.Size(74, 25);
			this.metroLabel4.TabIndex = 24;
			this.metroLabel4.Text = "Updates";
			this.metroLabel4.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel4.UseCustomForeColor = true;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.metroLabel7);
			this.panel1.Controls.Add(this.metroLabel6);
			this.panel1.Controls.Add(this.metroLabel5);
			this.panel1.ForeColor = global::System.Drawing.SystemColors.WindowFrame;
			this.panel1.Location = new global::System.Drawing.Point(38, 404);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(512, 128);
			this.panel1.TabIndex = 25;
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.Location = new global::System.Drawing.Point(361, 6);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new global::System.Drawing.Size(115, 114);
			this.metroLabel7.TabIndex = 26;
			this.metroLabel7.Text = "Website soon\r\n\r\nNeed help?\r\n\r\nDM hugzho#1337 \r\nor blink#9999";
			this.metroLabel7.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.ForeColor = global::System.Drawing.Color.Aqua;
			this.metroLabel6.Location = new global::System.Drawing.Point(203, 57);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new global::System.Drawing.Size(95, 19);
			this.metroLabel6.TabIndex = 25;
			this.metroLabel6.Text = "Discord Server";
			this.metroLabel6.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel6.UseCustomForeColor = true;
			this.metroLabel6.Click += new global::System.EventHandler(this.metroLabel6_Click);
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new global::System.Drawing.Point(15, 6);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new global::System.Drawing.Size(150, 114);
			this.metroLabel5.TabIndex = 24;
			this.metroLabel5.Text = "May 23rd\r\n- API Update\r\n- Fixed Bugs\r\nMay 16th\r\n- Updated Virtualization\r\n- Config System";
			this.metroLabel5.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(604, 555);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.metroLabel4);
			base.Controls.Add(this.metroLabel3);
			base.Controls.Add(this.metroLabel2);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroCheckBox19);
			base.Controls.Add(this.metroCheckBox18);
			base.Controls.Add(this.metroCheckBox17);
			base.Controls.Add(this.metroCheckBox16);
			base.Controls.Add(this.metroCheckBox15);
			base.Controls.Add(this.metroCheckBox14);
			base.Controls.Add(this.metroCheckBox13);
			base.Controls.Add(this.metroCheckBox12);
			base.Controls.Add(this.metroCheckBox11);
			base.Controls.Add(this.metroCheckBox10);
			base.Controls.Add(this.metroCheckBox9);
			base.Controls.Add(this.metroCheckBox8);
			base.Controls.Add(this.metroCheckBox7);
			base.Controls.Add(this.metroCheckBox6);
			base.Controls.Add(this.metroCheckBox5);
			base.Controls.Add(this.metroCheckBox4);
			base.Controls.Add(this.metroCheckBox3);
			base.Controls.Add(this.metroCheckBox2);
			base.Controls.Add(this.metroCheckBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form2";
			base.Resizable = false;
			base.ShadowType = global::MetroFramework.Forms.MetroFormShadowType.None;
			this.Text = "AtomicProtector | Main";
			base.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			base.Load += new global::System.EventHandler(this.Form2_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000082 RID: 130
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000083 RID: 131
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox1;

		// Token: 0x04000084 RID: 132
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox2;

		// Token: 0x04000085 RID: 133
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox3;

		// Token: 0x04000086 RID: 134
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox4;

		// Token: 0x04000087 RID: 135
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox5;

		// Token: 0x04000088 RID: 136
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox6;

		// Token: 0x04000089 RID: 137
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox7;

		// Token: 0x0400008A RID: 138
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox8;

		// Token: 0x0400008B RID: 139
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox9;

		// Token: 0x0400008C RID: 140
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox10;

		// Token: 0x0400008D RID: 141
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox11;

		// Token: 0x0400008E RID: 142
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox12;

		// Token: 0x0400008F RID: 143
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox13;

		// Token: 0x04000090 RID: 144
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox14;

		// Token: 0x04000091 RID: 145
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox15;

		// Token: 0x04000092 RID: 146
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox16;

		// Token: 0x04000093 RID: 147
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox17;

		// Token: 0x04000094 RID: 148
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox18;

		// Token: 0x04000095 RID: 149
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox19;

		// Token: 0x04000096 RID: 150
		private global::MetroFramework.Controls.MetroButton metroButton1;

		// Token: 0x04000097 RID: 151
		private global::MetroFramework.Controls.MetroLabel metroLabel1;

		// Token: 0x04000098 RID: 152
		private global::MetroFramework.Controls.MetroTextBox metroTextBox1;

		// Token: 0x04000099 RID: 153
		private global::MetroFramework.Controls.MetroButton metroButton2;

		// Token: 0x0400009A RID: 154
		private global::MetroFramework.Controls.MetroLabel metroLabel2;

		// Token: 0x0400009B RID: 155
		private global::MetroFramework.Controls.MetroLabel metroLabel3;

		// Token: 0x0400009C RID: 156
		private global::MetroFramework.Controls.MetroLabel metroLabel4;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400009E RID: 158
		private global::MetroFramework.Controls.MetroLabel metroLabel5;

		// Token: 0x0400009F RID: 159
		private global::MetroFramework.Controls.MetroLabel metroLabel6;

		// Token: 0x040000A0 RID: 160
		private global::MetroFramework.Controls.MetroLabel metroLabel7;
	}
}
