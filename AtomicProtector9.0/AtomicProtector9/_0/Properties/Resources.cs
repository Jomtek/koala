using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AtomicProtector9._0.Properties
{
	// Token: 0x0200003C RID: 60
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000118 RID: 280 RVA: 0x0000242E File Offset: 0x0000062E
		internal Resources()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000119 RID: 281 RVA: 0x0001765C File Offset: 0x0001585C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("AtomicProtector9._0.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600011A RID: 282 RVA: 0x000176A4 File Offset: 0x000158A4
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00002438 File Offset: 0x00000638
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x040000A1 RID: 161
		private static ResourceManager resourceMan;

		// Token: 0x040000A2 RID: 162
		private static CultureInfo resourceCulture;
	}
}
