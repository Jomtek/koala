namespace AtomicProtector9._0
{
	// Token: 0x02000039 RID: 57
	public partial class Form1 : global::MetroFramework.Forms.MetroForm
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x00014448 File Offset: 0x00012648
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00014480 File Offset: 0x00012680
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AtomicProtector9._0.Form1));
			this.metroTextBox1 = new global::MetroFramework.Controls.MetroTextBox();
			this.metroLabel1 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLabel2 = new global::MetroFramework.Controls.MetroLabel();
			this.metroLink1 = new global::MetroFramework.Controls.MetroLink();
			this.metroLabel3 = new global::MetroFramework.Controls.MetroLabel();
			global::MetroFramework.Controls.MetroButton metroButton = new global::MetroFramework.Controls.MetroButton();
			base.SuspendLayout();
			metroButton.Location = new global::System.Drawing.Point(86, 154);
			metroButton.Name = "metroButton1";
			metroButton.Size = new global::System.Drawing.Size(126, 34);
			metroButton.TabIndex = 1;
			metroButton.Text = "Login";
			metroButton.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			metroButton.UseSelectable = true;
			metroButton.Click += new global::System.EventHandler(this.metroButton1_Click);
			this.metroTextBox1.BackColor = global::System.Drawing.Color.FromArgb(114, 137, 218);
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new global::System.Drawing.Point(194, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new global::System.Drawing.Size(21, 21);
			this.metroTextBox1.CustomButton.Style = global::MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.ForeColor = global::System.Drawing.Color.FromArgb(114, 137, 218);
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new global::System.Drawing.Point(39, 111);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new global::System.Drawing.Size(216, 23);
			this.metroTextBox1.TabIndex = 0;
			this.metroTextBox1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = global::System.Drawing.Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Pixel);
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = global::System.Drawing.Color.Transparent;
			this.metroLabel1.Location = new global::System.Drawing.Point(63, 211);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new global::System.Drawing.Size(32, 19);
			this.metroLabel1.TabIndex = 2;
			this.metroLabel1.Text = "Join";
			this.metroLabel1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.ForeColor = global::System.Drawing.Color.Transparent;
			this.metroLabel2.Location = new global::System.Drawing.Point(183, 212);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new global::System.Drawing.Size(60, 19);
			this.metroLabel2.TabIndex = 3;
			this.metroLabel2.Text = "For Help";
			this.metroLabel2.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLink1.ForeColor = global::System.Drawing.Color.Cyan;
			this.metroLink1.Location = new global::System.Drawing.Point(88, 210);
			this.metroLink1.Name = "metroLink1";
			this.metroLink1.Size = new global::System.Drawing.Size(102, 23);
			this.metroLink1.Style = global::MetroFramework.MetroColorStyle.Teal;
			this.metroLink1.TabIndex = 4;
			this.metroLink1.Text = "Discord Server";
			this.metroLink1.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLink1.UseCustomForeColor = true;
			this.metroLink1.UseSelectable = true;
			this.metroLink1.Click += new global::System.EventHandler(this.metroLink1_Click);
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new global::System.Drawing.Point(88, 100);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new global::System.Drawing.Size(108, 19);
			this.metroLabel3.TabIndex = 5;
			this.metroLabel3.Text = "Login saved, wait";
			this.metroLabel3.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel3.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(312, 252);
			base.Controls.Add(this.metroLabel3);
			base.Controls.Add(this.metroLabel2);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.metroLink1);
			base.Controls.Add(metroButton);
			base.Controls.Add(this.metroTextBox1);
			this.ForeColor = global::System.Drawing.SystemColors.Control;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			base.Resizable = false;
			this.Text = "AtomicProtector | Login";
			base.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400007C RID: 124
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400007D RID: 125
		private global::MetroFramework.Controls.MetroTextBox metroTextBox1;

		// Token: 0x0400007E RID: 126
		private global::MetroFramework.Controls.MetroLabel metroLabel1;

		// Token: 0x0400007F RID: 127
		private global::MetroFramework.Controls.MetroLabel metroLabel2;

		// Token: 0x04000080 RID: 128
		private global::MetroFramework.Controls.MetroLink metroLink1;

		// Token: 0x04000081 RID: 129
		private global::MetroFramework.Controls.MetroLabel metroLabel3;
	}
}
