using System;
using System.Collections.Generic;
using System.Linq;
using Blink_Obfuscator_1._0.Runtime;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000014 RID: 20
	internal class Anti_Fiddler
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00005834 File Offset: 0x00003A34
		public static void Execute(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Fiddler).Module);
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Fiddler).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			MethodDef method2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Init");
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
			foreach (MethodDef methodDef2 in module.GlobalType.Methods)
			{
				bool flag = methodDef2.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef2);
					break;
				}
			}
		}
	}
}
