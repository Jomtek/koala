using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000029 RID: 41
	internal class KoiVM_Fake_Watermark
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x0000E128 File Offset: 0x0000C328
		public static void Execute(ModuleDef md)
		{
			TypeDef globalType = md.GlobalType;
			TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
			globalType.Name = "BlinkVM";
			globalType.BaseType = md.CorLibTypes.GetTypeRef("System", "Object");
			md.Types.Insert(0, typeDefUser);
			MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
			MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
			methodDef.Name = "BlinkVM";
			methodDef.IsRuntimeSpecialName = false;
			methodDef.IsSpecialName = false;
			methodDef.Access = MethodAttributes.PrivateScope;
			methodDef2.Body = new CilBody(true, new List<Instruction>
			{
				Instruction.Create(OpCodes.Call, methodDef),
				Instruction.Create(OpCodes.Ret)
			}, new List<ExceptionHandler>(), new List<Local>());
			for (int i = 0; i < globalType.Methods.Count; i++)
			{
				MethodDef methodDef3 = globalType.Methods[i];
				bool isNative = methodDef3.IsNative;
				if (isNative)
				{
					MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
					methodDefUser.Attributes = (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static);
					methodDefUser.Body = new CilBody();
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					globalType.Methods[i] = methodDefUser;
					typeDefUser.Methods.Add(methodDef3);
				}
			}
		}
	}
}
