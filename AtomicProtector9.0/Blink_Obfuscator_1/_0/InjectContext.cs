using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Blink_Obfuscator_1._0
{
	// Token: 0x02000002 RID: 2
	public class InjectContext
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000206F File Offset: 0x0000026F
		public InjectContext(ModuleDef module, ModuleDef target)
		{
			this.OriginModule = module;
			this.TargetModule = target;
			this.<Importer>k__BackingField = new Importer(target, ImporterOptions.TryToUseTypeDefs);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000209F File Offset: 0x0000029F
		public Importer Importer
		{
			get
			{
				return this.<Importer>k__BackingField;
			}
		}

		// Token: 0x04000001 RID: 1
		public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

		// Token: 0x04000002 RID: 2
		public readonly ModuleDef OriginModule;

		// Token: 0x04000003 RID: 3
		public readonly ModuleDef TargetModule;

		// Token: 0x04000004 RID: 4
		private readonly Importer <Importer>k__BackingField;
	}
}
