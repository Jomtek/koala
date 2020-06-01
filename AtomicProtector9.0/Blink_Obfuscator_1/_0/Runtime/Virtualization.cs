using System;
using System.Windows.Forms;

namespace Blink_Obfuscator_1._0.Runtime
{
	// Token: 0x0200000B RID: 11
	internal class Virtualization
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00003B60 File Offset: 0x00001D60
		public static object LoadField(object method, uint key, uint key2)
		{
			return method;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003B74 File Offset: 0x00001D74
		public static float LoadF(float LoadKey, string LoadKey2, string Mode)
		{
			bool flag = Mode == "Switch-Base";
			float result;
			if (flag)
			{
				uint num = (uint)new Random().Next(1, 999999);
				bool flag2 = LoadKey2 == "BlinkVM3";
				if (flag2)
				{
					MessageBox.Show("BlinkVM", "BlinkVM");
				}
				byte b = 1;
				bool flag3 = b != byte.MaxValue;
				if (flag3)
				{
					b = 3;
				}
				string text = b.ToString();
				LoadKey += num;
				LoadKey -= num;
				result = LoadKey / 999f;
			}
			else
			{
				bool flag4 = Mode == "Array";
				if (flag4)
				{
					uint num2 = (uint)new Random().Next(1, 999999);
					bool flag5 = LoadKey2 == "BlinkVM3";
					if (flag5)
					{
						MessageBox.Show("BlinkVM", "BlinkVM");
					}
					byte b2 = 1;
					bool flag6 = b2 != byte.MaxValue;
					if (flag6)
					{
						b2 = 3;
					}
					string text2 = b2.ToString();
					LoadKey += num2;
					LoadKey -= num2;
					result = LoadKey / 1200f;
				}
				else
				{
					bool flag7 = Mode == "Dynamic";
					if (flag7)
					{
						uint num3 = (uint)new Random().Next(1, 999999);
						bool flag8 = LoadKey2 == "BlinkVM3";
						if (flag8)
						{
							MessageBox.Show("BlinkVM", "BlinkVM");
						}
						byte b3 = 1;
						bool flag9 = b3 != byte.MaxValue;
						if (flag9)
						{
							b3 = 3;
						}
						string text3 = b3.ToString();
						LoadKey += num3;
						LoadKey -= num3;
						result = LoadKey / 2225f;
					}
					else
					{
						bool flag10 = Mode == "UMethod";
						if (flag10)
						{
							uint num4 = (uint)new Random().Next(1, 999999);
							bool flag11 = LoadKey2 == "BlinkVM3";
							if (flag11)
							{
								MessageBox.Show("BlinkVM", "BlinkVM");
							}
							byte b4 = 1;
							bool flag12 = b4 != byte.MaxValue;
							if (flag12)
							{
								b4 = 3;
							}
							string text4 = b4.ToString();
							LoadKey += num4;
							LoadKey -= num4;
							result = LoadKey / 3854f;
						}
						else
						{
							bool flag13 = Mode == "DynamicUInt";
							if (flag13)
							{
								uint num5 = (uint)new Random().Next(1, 999999);
								bool flag14 = LoadKey2 == "BlinkVM3";
								if (flag14)
								{
									MessageBox.Show("BlinkVM", "BlinkVM");
								}
								byte b5 = 1;
								bool flag15 = b5 != byte.MaxValue;
								if (flag15)
								{
									b5 = 3;
								}
								string text5 = b5.ToString();
								LoadKey += num5;
								LoadKey -= num5;
								result = LoadKey / 7964f;
							}
							else
							{
								result = 0f;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003E2C File Offset: 0x0000202C
		public static uint Load(uint LoadKey, string LoadKey2, string Mode)
		{
			bool flag = Mode == "Switch-Base";
			uint result;
			if (flag)
			{
				uint num = (uint)new Random().Next(1, 999999);
				bool flag2 = LoadKey2 == "BlinkVM3";
				if (flag2)
				{
					MessageBox.Show("BlinkVM", "BlinkVM");
				}
				byte b = 1;
				bool flag3 = b != byte.MaxValue;
				if (flag3)
				{
					b = 3;
				}
				string text = b.ToString();
				LoadKey += num;
				LoadKey -= num;
				result = LoadKey / 999U;
			}
			else
			{
				bool flag4 = Mode == "Array";
				if (flag4)
				{
					uint num2 = (uint)new Random().Next(1, 999999);
					bool flag5 = LoadKey2 == "BlinkVM3";
					if (flag5)
					{
						MessageBox.Show("BlinkVM", "BlinkVM");
					}
					byte b2 = 1;
					bool flag6 = b2 != byte.MaxValue;
					if (flag6)
					{
						b2 = 3;
					}
					string text2 = b2.ToString();
					LoadKey += num2;
					LoadKey -= num2;
					result = LoadKey / 1200U;
				}
				else
				{
					bool flag7 = Mode == "Dynamic";
					if (flag7)
					{
						uint num3 = (uint)new Random().Next(1, 999999);
						bool flag8 = LoadKey2 == "BlinkVM3";
						if (flag8)
						{
							MessageBox.Show("BlinkVM", "BlinkVM");
						}
						byte b3 = 1;
						bool flag9 = b3 != byte.MaxValue;
						if (flag9)
						{
							b3 = 3;
						}
						string text3 = b3.ToString();
						LoadKey += num3;
						LoadKey -= num3;
						result = LoadKey / 2225U;
					}
					else
					{
						bool flag10 = Mode == "UMethod";
						if (flag10)
						{
							uint num4 = (uint)new Random().Next(1, 999999);
							bool flag11 = LoadKey2 == "BlinkVM3";
							if (flag11)
							{
								MessageBox.Show("BlinkVM", "BlinkVM");
							}
							byte b4 = 1;
							bool flag12 = b4 != byte.MaxValue;
							if (flag12)
							{
								b4 = 3;
							}
							string text4 = b4.ToString();
							LoadKey += num4;
							LoadKey -= num4;
							result = LoadKey / 3854U;
						}
						else
						{
							bool flag13 = Mode == "DynamicUInt";
							if (flag13)
							{
								uint num5 = (uint)new Random().Next(1, 999999);
								bool flag14 = LoadKey2 == "BlinkVM3";
								if (flag14)
								{
									MessageBox.Show("BlinkVM", "BlinkVM");
								}
								byte b5 = 1;
								bool flag15 = b5 != byte.MaxValue;
								if (flag15)
								{
									b5 = 3;
								}
								string text5 = b5.ToString();
								LoadKey += num5;
								LoadKey -= num5;
								result = LoadKey / 7964U;
							}
							else
							{
								result = 0U;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0200000C RID: 12
		public struct BlinksVM
		{
			// Token: 0x06000025 RID: 37 RVA: 0x000040CC File Offset: 0x000022CC
			public static object LoadUInt(uint x, string LoadKey)
			{
				bool flag = LoadKey == "BlinkVM";
				object result;
				if (flag)
				{
					result = "BlinkVM";
				}
				else
				{
					bool flag2 = LoadKey == "BlinkVM";
					if (flag2)
					{
						result = "BlinkVM";
					}
					else
					{
						bool flag3 = LoadKey == "BlinkVM";
						if (flag3)
						{
							result = "BlinkVM";
						}
						else
						{
							bool flag4 = LoadKey == "BlinkVM";
							if (flag4)
							{
								result = "BlinkVM";
							}
							else
							{
								bool flag5 = LoadKey == "BlinkVM";
								if (flag5)
								{
									result = "BlinkVM";
								}
								else
								{
									bool flag6 = LoadKey == "BlinkVM";
									if (flag6)
									{
										result = "BlinkVM";
									}
									else
									{
										bool flag7 = LoadKey == "BlinkVM";
										if (flag7)
										{
											result = "BlinkVM";
										}
										else
										{
											bool flag8 = LoadKey == "BlinkVM";
											if (flag8)
											{
												result = "BlinkVM";
											}
											else
											{
												bool flag9 = LoadKey == "BlinkVM";
												if (flag9)
												{
													result = "BlinkVM";
												}
												else
												{
													bool flag10 = LoadKey == "BlinkVM";
													if (flag10)
													{
														result = "BlinkVM";
													}
													else
													{
														bool flag11 = LoadKey == "BlinkVM";
														if (flag11)
														{
															result = "BlinkVM";
														}
														else
														{
															bool flag12 = x == 1U;
															if (flag12)
															{
																result = "BlinkVM";
															}
															else
															{
																result = x;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				return result;
			}
		}

		// Token: 0x0200000D RID: 13
		// (Invoke) Token: 0x06000027 RID: 39
		public delegate void BlinkVMLoad(uint LoadKey, string LoadKey2, string Mode);

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x0600002B RID: 43
		public delegate void BlinkVMLoad1(uint LoadKey, string LoadKey2, string Mode);

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x0600002F RID: 47
		public delegate void BlinkVMLoad2(uint LoadKey, string LoadKey2, string Mode);

		// Token: 0x02000010 RID: 16
		// (Invoke) Token: 0x06000033 RID: 51
		public delegate void BlinkVMLoad3(uint LoadKey, string LoadKey2, string Mode);
	}
}
