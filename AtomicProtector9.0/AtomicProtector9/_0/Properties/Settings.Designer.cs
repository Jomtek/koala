﻿using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace AtomicProtector9._0.Properties
{
	// Token: 0x0200003D RID: 61
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600011C RID: 284 RVA: 0x000176BC File Offset: 0x000158BC
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000A3 RID: 163
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
