using System;
using System.Collections.Generic;
using System.Linq;
using Blink_Obfuscator_1._0.Runtime;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000019 RID: 25
	internal class AntiDump
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00005C0C File Offset: 0x00003E0C
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(AntiDump).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(AntiDump).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			AntiDump.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Initialize");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00005CF4 File Offset: 0x00003EF4
		public static void Inject(ModuleDef md)
		{
			AntiDump.InjectClass(md);
			MethodDef methodDef = md.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, AntiDump.init));
		}

		// Token: 0x04000039 RID: 57
		public static Random random = new Random();

		// Token: 0x0400003A RID: 58
		public static MethodDef init;
	}
}
