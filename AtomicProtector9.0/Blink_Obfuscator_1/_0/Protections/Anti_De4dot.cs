using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000012 RID: 18
	internal class Anti_De4dot
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00004BE0 File Offset: 0x00002DE0
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("⻏ㄩ讠ᐯ⻏⻏卄丿ᗪ\ud83d\udf57ᐯ卄⻏\ud83d\udf57ᗪ丂卄ᐯ\ud835\udcddㄩ讠山丂〤⼕丿闩ㄖ", length)
			select s[new Random().Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004C2C File Offset: 0x00002E2C
		public static void confuserex()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item = new TypeDefUser("", "ConfusedByAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(item);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004C80 File Offset: 0x00002E80
		public static void babel()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "BabelObfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004DB0 File Offset: 0x00002FB0
		public static void dotfuscator()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "DotfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004EE0 File Offset: 0x000030E0
		public static void ninerays()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "NineRays.Obfuscator.Evaluation", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005010 File Offset: 0x00003210
		public static void mango()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "();\t", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005140 File Offset: 0x00003340
		public static void bithelmet()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "EMyPID_8234_", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005270 File Offset: 0x00003470
		public static void crypto()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005324 File Offset: 0x00003524
		public static void yano()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "YanoAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000053D8 File Offset: 0x000035D8
		public static void dnguard()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "ZYXDNGuarder", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000548C File Offset: 0x0000368C
		public static void goliath()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "ObfuscatedByGoliath", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005540 File Offset: 0x00003740
		public static void agile()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "SecureTeam.Attributes.ObfuscatedByAgileDotNetAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000055F4 File Offset: 0x000037F4
		public static void smartassembly()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "SmartAssembly.Attributes.PoweredByAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000056A8 File Offset: 0x000038A8
		public static void xenocode()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000575C File Offset: 0x0000395C
		public static void RemoveDe4dot(ModuleDef md)
		{
			Anti_De4dot.publicmodule = md;
			for (int i = 1; i < 100; i++)
			{
				TypeDef typeDef = new TypeDefUser("", Renamer.Random(100) + Renamer.Random(100), md.CorLibTypes.GetTypeRef("System", "Attribute"));
				InterfaceImpl item = new InterfaceImplUser(typeDef);
				md.Types.Add(typeDef);
				typeDef.Interfaces.Add(item);
			}
			Anti_De4dot.xenocode();
			Anti_De4dot.smartassembly();
			Anti_De4dot.agile();
			Anti_De4dot.goliath();
			Anti_De4dot.yano();
			Anti_De4dot.crypto();
			Anti_De4dot.confuserex();
			Anti_De4dot.babel();
			Anti_De4dot.dotfuscator();
			Anti_De4dot.ninerays();
			Anti_De4dot.bithelmet();
			Anti_De4dot.mango();
			Anti_De4dot.dnguard();
		}

		// Token: 0x04000031 RID: 49
		private Random rnd = new Random();

		// Token: 0x04000032 RID: 50
		public static ModuleDef publicmodule;
	}
}
