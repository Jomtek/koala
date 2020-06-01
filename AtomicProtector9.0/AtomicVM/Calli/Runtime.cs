using System;
using System.Reflection;

namespace AtomicVM.Calli
{
	// Token: 0x02000043 RID: 67
	internal class Runtime
	{
		// Token: 0x06000150 RID: 336 RVA: 0x00018F14 File Offset: 0x00017114
		public static IntPtr ResolveToken(int token)
		{
			Module module = typeof(Runtime).Module;
			return module.ResolveMethod(token ^ Runtime.KeyI0).MethodHandle.GetFunctionPointer();
		}

		// Token: 0x040000B6 RID: 182
		public static readonly int KeyI0 = 0;
	}
}
