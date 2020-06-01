using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000038 RID: 56
	internal class Watermark
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00014310 File Offset: 0x00012510
		public static void Execute(ModuleDef module)
		{
			MethodDef source_method = module.GlobalType.FindOrCreateStaticConstructor();
			string value = "Obfuscated with Blink Obfuscator v1.0";
			MethodDef item = Watermark.CreateReturnMethodDef(value, source_method);
			module.GlobalType.Methods.Add(item);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001434C File Offset: 0x0001254C
		private static MethodDef CreateReturnMethodDef(string value, MethodDef source_method)
		{
			CorLibTypeSig @string = source_method.Module.CorLibTypes.String;
			MethodDef methodDef = new MethodDefUser("BlinkObfuscator", MethodSig.CreateStatic(@string), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
			{
				Body = new CilBody()
			};
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, value));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			return methodDef;
		}
	}
}
