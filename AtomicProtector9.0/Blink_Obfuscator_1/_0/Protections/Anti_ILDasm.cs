using System;
using dnlib.DotNet;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000018 RID: 24
	internal class Anti_ILDasm
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00005A5C File Offset: 0x00003C5C
		public static void Anti(ModuleDef md)
		{
			ModuleDef manifestModule = md.Assembly.ManifestModule;
			TypeRef typeRef = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressIldasmAttribute");
			MemberRefUser ctor = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef);
			CustomAttribute item = new CustomAttribute(ctor);
			manifestModule.CustomAttributes.Add(item);
			TypeRef typeRef2 = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnsafeValueTypeAttribute");
			MemberRefUser ctor2 = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef2);
			CustomAttribute item2 = new CustomAttribute(ctor2);
			manifestModule.CustomAttributes.Add(item2);
			TypeRef typeRef3 = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "RuntimeWrappedException");
			MemberRefUser ctor3 = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef3);
			CustomAttribute item3 = new CustomAttribute(ctor3);
			manifestModule.CustomAttributes.Add(item3);
			TypeRef typeRef4 = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnverifiableCodeAttribute");
			MemberRefUser ctor4 = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef4);
			CustomAttribute item4 = new CustomAttribute(ctor4);
			manifestModule.CustomAttributes.Add(item4);
			TypeRef typeRef5 = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressUnmanagedCodeSecurity");
			MemberRefUser ctor5 = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef5);
			CustomAttribute item5 = new CustomAttribute(ctor5);
			manifestModule.CustomAttributes.Add(item5);
		}
	}
}
