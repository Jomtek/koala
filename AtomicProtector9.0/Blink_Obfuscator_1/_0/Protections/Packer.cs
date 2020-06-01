using System;
using System.IO;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200002C RID: 44
	internal class Packer
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x0000E52C File Offset: 0x0000C72C
		public static void Pack(ModuleDef md, string directory)
		{
			string s = Convert.ToBase64String(File.ReadAllBytes(directory));
			ModuleDefUser moduleDefUser = new ModuleDefUser(Renamer.Random(25));
			moduleDefUser.Kind = ModuleKind.Console;
			AssemblyDefUser assemblyDefUser = new AssemblyDefUser(Renamer.Random(25), new Version(Packer.random.Next(1, 9), Packer.random.Next(1, 9), Packer.random.Next(1, 9), Packer.random.Next(1, 9)));
			assemblyDefUser.Modules.Add(moduleDefUser);
			TypeDefUser typeDefUser = new TypeDefUser(Renamer.Random(25), Renamer.Random(25), moduleDefUser.CorLibTypes.Object.TypeDefOrRef);
			typeDefUser.Attributes = dnlib.DotNet.TypeAttributes.NotPublic;
			moduleDefUser.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser("Main", MethodSig.CreateStatic(moduleDefUser.CorLibTypes.Void, new SZArraySig(moduleDefUser.CorLibTypes.String)));
			methodDefUser.Attributes = (dnlib.DotNet.MethodAttributes.Static | dnlib.DotNet.MethodAttributes.HideBySig);
			methodDefUser.ImplAttributes = dnlib.DotNet.MethodImplAttributes.IL;
			methodDefUser.ParamDefs.Add(new ParamDefUser("args", 1));
			typeDefUser.Methods.Add(methodDefUser);
			moduleDefUser.EntryPoint = methodDefUser;
			CilBody cilBody = new CilBody();
			methodDefUser.Body = cilBody;
			cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
			cilBody.Instructions.Add(OpCodes.Ldstr.ToInstruction(s));
			cilBody.Instructions.Add(OpCodes.Call.ToInstruction(methodDefUser.Module.Import(typeof(Convert).GetMethod("FromBase64String", new Type[]
			{
				typeof(string)
			}))));
			cilBody.Instructions.Add(OpCodes.Call.ToInstruction(methodDefUser.Module.Import(typeof(Assembly).GetMethod("Load", new Type[]
			{
				typeof(byte[])
			}))));
			cilBody.Instructions.Add(OpCodes.Callvirt.ToInstruction(methodDefUser.Module.Import(typeof(Assembly).GetMethod("get_EntryPoint", new Type[0]))));
			cilBody.Instructions.Add(OpCodes.Ldnull.ToInstruction());
			cilBody.Instructions.Add(OpCodes.Ldc_I4_1.ToInstruction());
			cilBody.Instructions.Add(OpCodes.Newarr.ToInstruction(methodDefUser.Module.Import(typeof(object))));
			cilBody.Instructions.Add(OpCodes.Callvirt.ToInstruction(methodDefUser.Module.Import(typeof(MethodBase).GetMethod("Invoke", new Type[]
			{
				typeof(object),
				typeof(object[])
			}))));
			cilBody.Instructions.Add(OpCodes.Pop.ToInstruction());
			cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
			moduleDefUser.Write(directory);
		}

		// Token: 0x0400005A RID: 90
		private static Random random = new Random();
	}
}
