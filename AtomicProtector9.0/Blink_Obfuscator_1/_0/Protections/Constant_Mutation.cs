using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x0200001C RID: 28
	internal class Constant_Mutation
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00006048 File Offset: 0x00004248
		public static bool CanObfuscateLDCI4(IList<Instruction> instructions, int i)
		{
			bool flag = instructions[i + 1].GetOperand() != null;
			if (flag)
			{
				bool flag2 = instructions[i + 1].Operand.ToString().Contains("bool");
				if (flag2)
				{
					return false;
				}
			}
			bool flag3 = instructions[i + 1].OpCode == OpCodes.Newobj;
			bool result;
			if (flag3)
			{
				result = false;
			}
			else
			{
				bool flag4 = instructions[i].GetLdcI4Value() == 0 || instructions[i].GetLdcI4Value() == 1;
				result = !flag4;
			}
			return result;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000060DC File Offset: 0x000042DC
		public static void Execute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef method in typeDef.Methods)
				{
					Constant_Mutation.Mutation(method);
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006168 File Offset: 0x00004368
		public static void EmptyType(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			if (flag)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				method.Body.Instructions[i].Operand = ldcI4Value - Type.EmptyTypes.Length;
				method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
				method.Body.Instructions.Insert(i + 1, OpCodes.Ldsfld.ToInstruction(method.Module.Import(typeof(Type).GetField("EmptyTypes"))));
				method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldlen));
				method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Add));
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000626C File Offset: 0x0000446C
		public static void DoubleParse(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			if (flag)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				double value = Constant_Mutation.RandomDouble(1.0, 1000.0);
				string s = Convert.ToString(value);
				double num = double.Parse(s);
				int num2 = ldcI4Value - (int)num;
				method.Body.Instructions[i].Operand = num2;
				method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
				method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, s));
				method.Body.Instructions.Insert(i + 2, OpCodes.Call.ToInstruction(method.Module.Import(typeof(double).GetMethod("Parse", new Type[]
				{
					typeof(string)
				}))));
				method.Body.Instructions.Insert(i + 3, OpCodes.Conv_I4.ToInstruction());
				method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Add));
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000063CC File Offset: 0x000045CC
		public static void Brs(MethodDef method)
		{
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				Instruction instruction = method.Body.Instructions[i];
				bool flag = instruction.IsLdcI4();
				if (flag)
				{
					int ldcI4Value = instruction.GetLdcI4Value();
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = ldcI4Value - 1;
					int value = Constant_Mutation.rnd.Next(100, 500);
					int value2 = Constant_Mutation.rnd.Next(1000, 5000);
					method.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(value));
					method.Body.Instructions.Insert(i + 2, Instruction.CreateLdcI4(value2));
					method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Clt));
					method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Conv_I4));
					method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Add));
					i += 5;
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006504 File Offset: 0x00004704
		public static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat<string>(chars, length)
			select s[Constant_Mutation.rnd.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000654C File Offset: 0x0000474C
		private static void Calc(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			if (flag)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				int num = Constant_Mutation.rnd.Next(-100, 10000);
				switch (Constant_Mutation.rnd.Next(1, 4))
				{
				case 1:
					method.Body.Instructions[i].Operand = ldcI4Value - num;
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Add.ToInstruction());
					i += 2;
					break;
				case 2:
					method.Body.Instructions[i].Operand = ldcI4Value + num;
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Sub.ToInstruction());
					i += 2;
					break;
				case 3:
					method.Body.Instructions[i].Operand = (ldcI4Value ^ num);
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Xor.ToInstruction());
					i += 2;
					break;
				case 4:
				{
					int ldcI4Value2 = method.Body.Instructions[i].GetLdcI4Value();
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions[i].Operand = ldcI4Value2 - 1;
					int value = Constant_Mutation.rnd.Next(100, 500);
					int value2 = Constant_Mutation.rnd.Next(1000, 5000);
					method.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(value));
					method.Body.Instructions.Insert(i + 2, Instruction.CreateLdcI4(value2));
					method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Clt));
					method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Conv_I4));
					method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Add));
					i += 5;
					break;
				}
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006828 File Offset: 0x00004A28
		private static double RandomDouble(double min, double max)
		{
			return new Random().NextDouble() * (max - min) + min;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000684C File Offset: 0x00004A4C
		public static void Abs(MethodDef method, ref int index)
		{
			IList<Instruction> instructions = method.Body.Instructions;
			int num = index + 1;
			index = num;
			instructions.Insert(num, new Instruction(OpCodes.Call, method.Module.Import(typeof(Math).GetMethod("Abs", new Type[]
			{
				typeof(int)
			}))));
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000068B0 File Offset: 0x00004AB0
		public static void MutationVirt(MethodDef method)
		{
			bool flag = !method.HasBody;
			if (!flag)
			{
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					bool flag2 = method.Body.Instructions[i].IsLdcI4();
					if (flag2)
					{
						Constant_Mutation.Abs(method, ref i);
					}
				}
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00006914 File Offset: 0x00004B14
		public static void Mutation(MethodDef method)
		{
			bool flag = !method.HasBody;
			if (!flag)
			{
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					bool flag2 = method.Body.Instructions[i].IsLdcI4();
					if (flag2)
					{
						Constant_Mutation.FloorReplacer(method, method.Body.Instructions[i], ref i);
						Constant_Mutation.EmptyType(method, ref i);
						Constant_Mutation.DoubleParse(method, ref i);
						Constant_Mutation.RoundReplacer(method, method.Body.Instructions[i], ref i);
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000069B8 File Offset: 0x00004BB8
		public static void Varible(MethodDef method, ref int index)
		{
			int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
			Local local = new Local(method.Module.CorLibTypes.Int32);
			method.Body.Variables.Add(local);
			method.Body.Instructions.Insert(0, new Instruction(OpCodes.Stloc, local));
			method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
			index += 2;
			method.Body.Instructions[index] = new Instruction(OpCodes.Ldloc, local);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006A6C File Offset: 0x00004C6C
		public static void Execute(MethodDef method, ref int index)
		{
			bool flag = method.Body.Instructions[index].OpCode != OpCodes.Call;
			if (flag)
			{
				int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
				Local local = new Local(method.Module.CorLibTypes.Int32);
				Local local2 = new Local(method.Module.CorLibTypes.Int32);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				int num = new Random().Next();
				int num2 = new Random().Next();
				bool flag2 = Convert.ToBoolean(new Random().Next(2));
				bool flag3 = flag2;
				int num3;
				if (flag3)
				{
					num3 = num2 - num;
				}
				else
				{
					num3 = new Random().Next();
					while (num3 + num == num2)
					{
						num3 = new Random().Next();
					}
				}
				method.Body.Instructions[index] = Instruction.CreateLdcI4(num);
				IList<Instruction> instructions = method.Body.Instructions;
				int num4 = index + 1;
				index = num4;
				instructions.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions2 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions2.Insert(num4, Instruction.CreateLdcI4(num3));
				IList<Instruction> instructions3 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions3.Insert(num4, new Instruction(OpCodes.Stloc, local2));
				IList<Instruction> instructions4 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions4.Insert(num4, new Instruction(OpCodes.Ldloc, local));
				IList<Instruction> instructions5 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions5.Insert(num4, new Instruction(OpCodes.Ldloc, local2));
				IList<Instruction> instructions6 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions6.Insert(num4, new Instruction(OpCodes.Add));
				IList<Instruction> instructions7 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions7.Insert(num4, new Instruction(OpCodes.Ldc_I4, num2));
				IList<Instruction> instructions8 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions8.Insert(num4, new Instruction(OpCodes.Ceq));
				Instruction instruction = OpCodes.Nop.ToInstruction();
				IList<Instruction> instructions9 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions9.Insert(num4, new Instruction(flag2 ? OpCodes.Brfalse : OpCodes.Brtrue, instruction));
				IList<Instruction> instructions10 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions10.Insert(num4, new Instruction(OpCodes.Nop));
				IList<Instruction> instructions11 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions11.Insert(num4, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
				IList<Instruction> instructions12 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions12.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions13 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions13.Insert(num4, new Instruction(OpCodes.Nop));
				Instruction instruction2 = OpCodes.Ldloc_S.ToInstruction(local);
				IList<Instruction> instructions14 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions14.Insert(num4, new Instruction(OpCodes.Br, instruction2));
				IList<Instruction> instructions15 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions15.Insert(num4, instruction);
				IList<Instruction> instructions16 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions16.Insert(num4, new Instruction(OpCodes.Ldc_I4, new Random().Next()));
				IList<Instruction> instructions17 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions17.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions18 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions18.Insert(num4, new Instruction(OpCodes.Nop));
				IList<Instruction> instructions19 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions19.Insert(num4, instruction2);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00006EA8 File Offset: 0x000050A8
		public static void Divsion(MethodDef method, ref int index)
		{
			int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
			int num = new Random().Next(1, 5);
			method.Body.Instructions[index].OpCode = OpCodes.Ldc_I4;
			method.Body.Instructions[index].Operand = ldcI4Value * num;
			IList<Instruction> instructions = method.Body.Instructions;
			int num2 = index + 1;
			index = num2;
			instructions.Insert(num2, new Instruction(OpCodes.Ldc_I4, num));
			IList<Instruction> instructions2 = method.Body.Instructions;
			num2 = index + 1;
			index = num2;
			instructions2.Insert(num2, new Instruction(OpCodes.Div));
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006F64 File Offset: 0x00005164
		public static void Process(MethodDef method, ref int index)
		{
			try
			{
				bool flag = method.Body.Instructions[index - 1].IsLdcI4() && method.Body.Instructions[index - 2].IsLdcI4();
				if (flag)
				{
					int ldcI4Value = method.Body.Instructions[index - 2].GetLdcI4Value();
					int ldcI4Value2 = method.Body.Instructions[index - 1].GetLdcI4Value();
					bool flag2 = ldcI4Value2 >= 3;
					if (flag2)
					{
						Local local = new Local(method.Module.CorLibTypes.Int32);
						method.Body.Variables.Add(local);
						method.Body.Instructions.Insert(0, new Instruction(OpCodes.Stloc, local));
						method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
						index += 2;
						method.Body.Instructions[index - 2].OpCode = OpCodes.Ldloc;
						method.Body.Instructions[index - 2].Operand = local;
						method.Body.Instructions[index - 1].OpCode = OpCodes.Nop;
						method.Body.Instructions[index].OpCode = OpCodes.Nop;
						int num = 0;
						for (int i = ldcI4Value2; i > 0; i >>= 1)
						{
							bool flag3 = (i & 1) == 1;
							if (flag3)
							{
								bool flag4 = num != 0;
								if (flag4)
								{
									IList<Instruction> instructions = method.Body.Instructions;
									int num2 = index + 1;
									index = num2;
									instructions.Insert(num2, new Instruction(OpCodes.Ldloc, local));
									IList<Instruction> instructions2 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions2.Insert(num2, new Instruction(OpCodes.Ldc_I4, num));
									IList<Instruction> instructions3 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions3.Insert(num2, new Instruction(OpCodes.Shl));
									IList<Instruction> instructions4 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions4.Insert(num2, new Instruction(OpCodes.Add));
								}
							}
							num++;
						}
						bool flag5 = (ldcI4Value2 & 1) == 0;
						if (flag5)
						{
							IList<Instruction> instructions5 = method.Body.Instructions;
							int num2 = index + 1;
							index = num2;
							instructions5.Insert(num2, new Instruction(OpCodes.Ldloc, local));
							IList<Instruction> instructions6 = method.Body.Instructions;
							num2 = index + 1;
							index = num2;
							instructions6.Insert(num2, new Instruction(OpCodes.Sub));
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000724C File Offset: 0x0000544C
		public bool Supported(Instruction instr)
		{
			return instr.OpCode == OpCodes.Mul;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000726C File Offset: 0x0000546C
		public static void StructGenerator(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			if (flag)
			{
				ITypeDefOrRef baseType = new Importer(method.Module).Import(typeof(ValueType));
				TypeDef structDef = new TypeDefUser(Constant_Mutation.RandomString(Constant_Mutation.rnd.Next(10, 30), "畹畞疲疷疹痲痹痹瘕番畐畞畵畵畲畲蘽蘐藴虜蘞虢謊謁abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01"), baseType);
				structDef.ClassLayout = new ClassLayoutUser(1, 0U);
				structDef.Attributes |= (TypeAttributes.Public | TypeAttributes.SequentialLayout | TypeAttributes.Sealed);
				List<Type> list = new List<Type>();
				int num = Constant_Mutation.rndsizevalues[Constant_Mutation.rnd.Next(0, 6)];
				list.Add(Constant_Mutation.GetType(num));
				list.ForEach(delegate(Type x)
				{
					structDef.Fields.Add(new FieldDefUser(Constant_Mutation.RandomString(Constant_Mutation.rnd.Next(10, 30), "畹畞疲疷疹痲痹痹瘕番畐畞畵畵畲畲蘽蘐藴虜蘞虢謊謁abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"), new FieldSig(new Importer(method.Module).Import(x).ToTypeSig()), FieldAttributes.Public));
				});
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				bool flag2 = Constant_Mutation.abc < 25;
				if (flag2)
				{
					method.Module.Types.Add(structDef);
					Constant_Mutation.Dick.Add(Constant_Mutation.abc++, new Tuple<TypeDef, int>(structDef, num));
					int num2 = ldcI4Value - num;
					method.Body.Instructions[i].Operand = num2;
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, structDef));
					method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
				}
				else
				{
					Tuple<TypeDef, int> tuple;
					Constant_Mutation.Dick.TryGetValue(Constant_Mutation.rnd.Next(1, 24), out tuple);
					int num3 = ldcI4Value - tuple.Item2;
					method.Body.Instructions[i].Operand = num3;
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, tuple.Item1));
					method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007574 File Offset: 0x00005774
		private static Type GetType(int operand)
		{
			if (operand <= 8)
			{
				switch (operand)
				{
				case 1:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(bool);
					case 1:
						return typeof(sbyte);
					case 2:
						return typeof(byte);
					}
					break;
				case 2:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(short);
					case 1:
						return typeof(ushort);
					case 2:
						return typeof(char);
					}
					break;
				case 3:
					break;
				case 4:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(int);
					case 1:
						return typeof(float);
					case 2:
						return typeof(uint);
					}
					break;
				default:
					if (operand == 8)
					{
						switch (Constant_Mutation.rnd.Next(0, 5))
						{
						case 0:
							return typeof(DateTime);
						case 1:
							return typeof(TimeSpan);
						case 2:
							return typeof(long);
						case 3:
							return typeof(double);
						case 4:
							return typeof(ulong);
						}
					}
					break;
				}
			}
			else
			{
				if (operand == 12)
				{
					return typeof(ConsoleKeyInfo);
				}
				if (operand == 16)
				{
					int num = Constant_Mutation.rnd.Next(0, 2);
					int num2 = num;
					if (num2 == 0)
					{
						return typeof(Guid);
					}
					if (num2 == 1)
					{
						return typeof(decimal);
					}
				}
			}
			return null;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000077AC File Offset: 0x000059AC
		public static List<Type> CreateTypeList(int size, out int total)
		{
			List<Type> list = new List<Type>();
			int num = 0;
			while (size != 0)
			{
				bool flag = 16 <= size;
				if (flag)
				{
					size -= 16;
					num += 16;
					list.Add(Constant_Mutation.GetType(16));
				}
				else
				{
					bool flag2 = 12 <= size;
					if (flag2)
					{
						size -= 12;
						num += 12;
						list.Add(Constant_Mutation.GetType(12));
					}
					else
					{
						bool flag3 = 8 <= size;
						if (flag3)
						{
							size -= 8;
							num += 8;
							list.Add(Constant_Mutation.GetType(8));
						}
						else
						{
							bool flag4 = 4 <= size;
							if (flag4)
							{
								size -= 4;
								num += 4;
								list.Add(Constant_Mutation.GetType(4));
							}
							else
							{
								bool flag5 = 2 <= size;
								if (flag5)
								{
									size -= 2;
									num += 2;
									list.Add(Constant_Mutation.GetType(2));
								}
								else
								{
									bool flag6 = 1 <= size;
									if (flag6)
									{
										size--;
										num++;
										list.Add(Constant_Mutation.GetType(1));
									}
								}
							}
						}
					}
				}
			}
			total = num;
			return list;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000078D4 File Offset: 0x00005AD4
		public static string RandomOrNo()
		{
			string[] array = new string[]
			{
				"CausalityTraceLevel",
				"BitConverter",
				"UnhandledExceptionEventHandler",
				"PinnedBufferMemoryStream",
				"RichTextBoxScrollBars",
				"RichTextBoxSelectionAttribute",
				"RichTextBoxSelectionTypes",
				"RichTextBoxStreamType",
				"RichTextBoxWordPunctuations",
				"RightToLeft",
				"RTLAwareMessageBox",
				"SafeNativeMethods",
				"SaveFileDialog",
				"Screen",
				"ScreenOrientation",
				"ScrollableControl",
				"ScrollBar",
				"ScrollBarRenderer",
				"ScrollBars",
				"ScrollButton",
				"ScrollEventArgs",
				"ScrollEventHandler",
				"ScrollEventType",
				"ScrollOrientation",
				"ScrollProperties",
				"SearchDirectionHint",
				"SearchForVirtualItemEventArgs",
				"SearchForVirtualItemEventHandler",
				"SecurityIDType",
				"SelectedGridItemChangedEventArgs",
				"SelectedGridItemChangedEventHandler",
				"SelectionMode",
				"SelectionRange",
				"SelectionRangeConverter",
				"SendKeys",
				"Shortcut",
				"SizeGripStyle",
				"SortOrder",
				"SpecialFolderEnumConverter",
				"SplitContainer",
				"Splitter",
				"SplitterCancelEventArgs",
				"SplitterCancelEventHandler",
				"SplitterEventArgs",
				"SplitterEventHandler",
				"SplitterPanel",
				"StatusBar",
				"StatusBarDrawItemEventArgs",
				"StatusBarDrawItemEventHandler",
				"StatusBarPanel",
				"StatusBarPanelAutoSize",
				"StatusBarPanelBorderStyle",
				"StatusBarPanelClickEventArgs",
				"StatusBarPanelClickEventHandler",
				"StatusBarPanelStyle",
				"StatusStrip",
				"StringSorter",
				"StringSource",
				"StructFormat",
				"SystemInformation",
				"SystemParameter",
				"TabAlignment",
				"TabAppearance",
				"TabControl",
				"TabControlAction",
				"TabControlCancelEventArgs",
				"TabControlCancelEventHandler",
				"TabControlEventArgs",
				"TabControlEventHandler",
				"TabDrawMode",
				"TableLayoutPanel",
				"TableLayoutControlCollection",
				"TableLayoutPanelCellBorderStyle",
				"TableLayoutPanelCellPosition",
				"TableLayoutPanelCellPositionTypeConverter",
				"TableLayoutPanelGrowStyle",
				"TableLayoutSettings",
				"SizeType",
				"ColumnStyle",
				"RowStyle",
				"TableLayoutStyle",
				"TableLayoutStyleCollection",
				"TableLayoutCellPaintEventArgs",
				"TableLayoutCellPaintEventHandler",
				"TableLayoutColumnStyleCollection",
				"TableLayoutRowStyleCollection",
				"TabPage",
				"TabRenderer",
				"TabSizeMode",
				"TextBox",
				"TextBoxAutoCompleteSourceConverter",
				"TextBoxBase",
				"TextBoxRenderer",
				"TextDataFormat",
				"TextImageRelation",
				"ThreadExceptionDialog",
				"TickStyle",
				"ToolBar",
				"ToolBarAppearance",
				"ToolBarButton",
				"ToolBarButtonClickEventArgs",
				"ToolBarButtonClickEventHandler",
				"ToolBarButtonStyle",
				"ToolBarTextAlign",
				"ToolStrip",
				"CachedItemHdcInfo",
				"MouseHoverTimer",
				"ToolStripSplitStackDragDropHandler",
				"ToolStripArrowRenderEventArgs",
				"ToolStripArrowRenderEventHandler",
				"ToolStripButton",
				"ToolStripComboBox",
				"ToolStripControlHost",
				"ToolStripDropDown",
				"ToolStripDropDownCloseReason",
				"ToolStripDropDownClosedEventArgs",
				"ToolStripDropDownClosedEventHandler",
				"ToolStripDropDownClosingEventArgs",
				"ToolStripDropDownClosingEventHandler",
				"ToolStripDropDownDirection",
				"ToolStripDropDownButton",
				"ToolStripDropDownItem",
				"ToolStripDropDownItemAccessibleObject",
				"ToolStripDropDownMenu",
				"ToolStripDropTargetManager",
				"ToolStripHighContrastRenderer",
				"ToolStripGrip",
				"ToolStripGripDisplayStyle",
				"ToolStripGripRenderEventArgs",
				"ToolStripGripRenderEventHandler",
				"ToolStripGripStyle",
				"ToolStripItem",
				"ToolStripItemImageIndexer",
				"ToolStripItemInternalLayout",
				"ToolStripItemAlignment",
				"ToolStripItemClickedEventArgs",
				"ToolStripItemClickedEventHandler",
				"ToolStripItemCollection",
				"ToolStripItemDisplayStyle",
				"ToolStripItemEventArgs",
				"ToolStripItemEventHandler",
				"ToolStripItemEventType",
				"ToolStripItemImageRenderEventArgs",
				"ToolStripItemImageRenderEventHandler",
				"ToolStripItemImageScaling",
				"ToolStripItemOverflow",
				"ToolStripItemPlacement",
				"ToolStripItemRenderEventArgs",
				"ToolStripItemRenderEventHandler",
				"ToolStripItemStates",
				"ToolStripItemTextRenderEventArgs",
				"ToolStripItemTextRenderEventHandler",
				"ToolStripLabel",
				"ToolStripLayoutStyle",
				"ToolStripManager",
				"ToolStripCustomIComparer",
				"MergeHistory",
				"MergeHistoryItem",
				"ToolStripManagerRenderMode",
				"ToolStripMenuItem",
				"MenuTimer",
				"ToolStripMenuItemInternalLayout",
				"ToolStripOverflow",
				"ToolStripOverflowButton",
				"ToolStripContainer",
				"ToolStripContentPanel",
				"ToolStripPanel",
				"ToolStripPanelCell",
				"ToolStripPanelRenderEventArgs",
				"ToolStripPanelRenderEventHandler",
				"ToolStripContentPanelRenderEventArgs",
				"ToolStripContentPanelRenderEventHandler",
				"ToolStripPanelRow",
				"ToolStripPointType",
				"ToolStripProfessionalRenderer",
				"ToolStripProfessionalLowResolutionRenderer",
				"ToolStripProgressBar",
				"ToolStripRenderer",
				"ToolStripRendererSwitcher",
				"ToolStripRenderEventArgs",
				"ToolStripRenderEventHandler",
				"ToolStripRenderMode",
				"ToolStripScrollButton",
				"ToolStripSeparator",
				"ToolStripSeparatorRenderEventArgs",
				"ToolStripSeparatorRenderEventHandler",
				"ToolStripSettings",
				"ToolStripSettingsManager",
				"ToolStripSplitButton",
				"ToolStripSplitStackLayout",
				"ToolStripStatusLabel",
				"ToolStripStatusLabelBorderSides",
				"ToolStripSystemRenderer",
				"ToolStripTextBox",
				"ToolStripTextDirection",
				"ToolStripLocationCancelEventArgs",
				"ToolStripLocationCancelEventHandler",
				"ToolTip",
				"ToolTipIcon",
				"TrackBar",
				"TrackBarRenderer",
				"TreeNode",
				"TreeNodeMouseClickEventArgs",
				"TreeNodeMouseClickEventHandler",
				"TreeNodeCollection",
				"TreeNodeConverter",
				"TreeNodeMouseHoverEventArgs",
				"TreeNodeMouseHoverEventHandler",
				"TreeNodeStates",
				"TreeView",
				"TreeViewAction",
				"TreeViewCancelEventArgs",
				"TreeViewCancelEventHandler",
				"TreeViewDrawMode",
				"TreeViewEventArgs",
				"TreeViewEventHandler",
				"TreeViewHitTestInfo",
				"TreeViewHitTestLocations",
				"TreeViewImageIndexConverter",
				"TreeViewImageKeyConverter",
				"Triangle",
				"TriangleDirection",
				"TypeValidationEventArgs",
				"TypeValidationEventHandler",
				"UICues",
				"UICuesEventArgs",
				"UICuesEventHandler",
				"UpDownBase",
				"UpDownEventArgs",
				"UpDownEventHandler",
				"UserControl",
				"ValidationConstraints",
				"View",
				"VScrollBar",
				"VScrollProperties",
				"WebBrowser",
				"WebBrowserEncryptionLevel",
				"WebBrowserReadyState",
				"WebBrowserRefreshOption",
				"WebBrowserBase",
				"WebBrowserContainer",
				"WebBrowserDocumentCompletedEventHandler",
				"WebBrowserDocumentCompletedEventArgs",
				"WebBrowserHelper",
				"WebBrowserNavigatedEventHandler",
				"WebBrowserNavigatedEventArgs",
				"WebBrowserNavigatingEventHandler",
				"WebBrowserNavigatingEventArgs",
				"WebBrowserProgressChangedEventHandler",
				"WebBrowserProgressChangedEventArgs",
				"WebBrowserSiteBase",
				"WebBrowserUriTypeConverter",
				"WinCategoryAttribute",
				"WindowsFormsSection",
				"WindowsFormsSynchronizationContext",
				"IntSecurity",
				"WindowsFormsUtils",
				"IComponentEditorPageSite",
				"LayoutSettings",
				"PageSetupDialog",
				"PrintControllerWithStatusDialog",
				"PrintDialog",
				"PrintPreviewControl",
				"PrintPreviewDialog",
				"TextFormatFlags",
				"TextRenderer",
				"WindowsGraphicsWrapper",
				"SRDescriptionAttribute",
				"SRCategoryAttribute",
				"SR",
				"VisualStyleElement",
				"VisualStyleInformation",
				"VisualStyleRenderer",
				"VisualStyleState",
				"ComboBoxState",
				"CheckBoxState",
				"GroupBoxState",
				"HeaderItemState",
				"PushButtonState",
				"RadioButtonState",
				"ScrollBarArrowButtonState",
				"ScrollBarState",
				"ScrollBarSizeBoxState",
				"TabItemState",
				"TextBoxState",
				"ToolBarState",
				"TrackBarThumbState",
				"BackgroundType",
				"BorderType",
				"ImageOrientation",
				"SizingType",
				"FillType",
				"HorizontalAlign",
				"ContentAlignment",
				"VerticalAlignment",
				"OffsetType",
				"IconEffect",
				"TextShadowType",
				"GlyphType",
				"ImageSelectType",
				"TrueSizeScalingType",
				"GlyphFontSizingType",
				"ColorProperty",
				"EnumProperty",
				"FilenameProperty",
				"FontProperty",
				"IntegerProperty",
				"PointProperty",
				"MarginProperty",
				"StringProperty",
				"BooleanProperty",
				"Edges",
				"EdgeStyle",
				"EdgeEffects",
				"TextMetrics",
				"TextMetricsPitchAndFamilyValues",
				"TextMetricsCharacterSet",
				"HitTestOptions",
				"HitTestCode",
				"ThemeSizeType",
				"VisualStyleDocProperty",
				"VisualStyleSystemProperty",
				"ArrayElementGridEntry",
				"CategoryGridEntry",
				"DocComment",
				"DropDownButton",
				"DropDownButtonAdapter",
				"GridEntry",
				"AttributeTypeSorter",
				"GridEntryRecreateChildrenEventHandler",
				"GridEntryRecreateChildrenEventArgs",
				"GridEntryCollection",
				"GridErrorDlg",
				"GridToolTip",
				"HotCommands",
				"ImmutablePropertyDescriptorGridEntry",
				"IRootGridEntry",
				"MergePropertyDescriptor",
				"MultiPropertyDescriptorGridEntry",
				"MultiSelectRootGridEntry",
				"PropertiesTab",
				"PropertyDescriptorGridEntry",
				"PropertyGridCommands",
				"PropertyGridView",
				"SingleSelectRootGridEntry",
				"ComponentEditorForm",
				"ComponentEditorPage",
				"EventsTab",
				"IUIService",
				"IWindowsFormsEditorService",
				"PropertyTab",
				"ToolStripItemDesignerAvailability",
				"ToolStripItemDesignerAvailabilityAttribute",
				"WindowsFormsComponentEditor",
				"BaseCAMarshaler",
				"Com2AboutBoxPropertyDescriptor",
				"Com2ColorConverter",
				"Com2ComponentEditor",
				"Com2DataTypeToManagedDataTypeConverter",
				"Com2Enum",
				"Com2EnumConverter",
				"Com2ExtendedBrowsingHandler",
				"Com2ExtendedTypeConverter",
				"Com2FontConverter",
				"Com2ICategorizePropertiesHandler",
				"Com2IDispatchConverter",
				"Com2IManagedPerPropertyBrowsingHandler",
				"Com2IPerPropertyBrowsingHandler",
				"Com2IProvidePropertyBuilderHandler",
				"Com2IVsPerPropertyBrowsingHandler",
				"Com2PictureConverter",
				"Com2Properties",
				"Com2PropertyBuilderUITypeEditor",
				"Com2PropertyDescriptor",
				"GetAttributesEvent",
				"Com2EventHandler",
				"GetAttributesEventHandler",
				"GetNameItemEvent",
				"GetNameItemEventHandler",
				"DynamicMetaObjectProviderDebugView",
				"ExpressionTreeCallRewriter",
				"ICSharpInvokeOrInvokeMemberBinder",
				"ResetBindException",
				"RuntimeBinder",
				"RuntimeBinderController",
				"RuntimeBinderException",
				"RuntimeBinderInternalCompilerException",
				"SpecialNames",
				"SymbolTable",
				"RuntimeBinderExtensions",
				"NameManager",
				"Name",
				"NameTable",
				"OperatorKind",
				"PredefinedName",
				"PredefinedType",
				"TokenFacts",
				"TokenKind",
				"OutputContext",
				"UNSAFESTATES",
				"CheckedContext",
				"BindingFlag",
				"ExpressionBinder",
				"BinOpKind",
				"BinOpMask",
				"CandidateFunctionMember",
				"ConstValKind",
				"CONSTVAL",
				"ConstValFactory",
				"ConvKind",
				"CONVERTTYPE",
				"BetterType",
				"ListExtensions",
				"CConversions",
				"Operators",
				"UdConvInfo",
				"ArgInfos",
				"BodyType",
				"ConstCastResult",
				"AggCastResult",
				"UnaryOperatorSignatureFindResult",
				"UnaOpKind",
				"UnaOpMask",
				"OpSigFlags",
				"LiftFlags",
				"CheckLvalueKind",
				"BinOpFuncKind",
				"UnaOpFuncKind",
				"ExpressionKind",
				"ExpressionKindExtensions",
				"EXPRExtensions",
				"ExprFactory",
				"EXPRFLAG",
				"FileRecord",
				"FUNDTYPE",
				"GlobalSymbolContext",
				"InputFile",
				"LangCompiler",
				"MemLookFlags",
				"MemberLookup",
				"CMemberLookupResults",
				"mdToken",
				"CorAttributeTargets",
				"MethodKindEnum",
				"MethodTypeInferrer",
				"NameGenerator",
				"CNullable",
				"NullableCallLiftKind",
				"CONSTRESKIND",
				"LambdaParams",
				"TypeOrSimpleNameResolution",
				"InitializerKind",
				"ConstantStringConcatenation",
				"ForeachKind",
				"PREDEFATTR",
				"PREDEFMETH",
				"PREDEFPROP",
				"MethodRequiredEnum",
				"MethodCallingConventionEnum",
				"MethodSignatureEnum",
				"PredefinedMethodInfo",
				"PredefinedPropertyInfo",
				"PredefinedMembers",
				"ACCESSERROR",
				"CSemanticChecker",
				"SubstTypeFlags",
				"SubstContext",
				"CheckConstraintsFlags",
				"TypeBind",
				"UtilityTypeExtensions",
				"SymWithType",
				"MethPropWithType",
				"MethWithType",
				"PropWithType",
				"EventWithType",
				"FieldWithType",
				"MethPropWithInst",
				"MethWithInst",
				"AggregateDeclaration",
				"Declaration",
				"GlobalAttributeDeclaration",
				"ITypeOrNamespace",
				"AggregateSymbol",
				"AssemblyQualifiedNamespaceSymbol",
				"EventSymbol",
				"FieldSymbol",
				"IndexerSymbol",
				"LabelSymbol",
				"LocalVariableSymbol",
				"MethodOrPropertySymbol",
				"MethodSymbol",
				"InterfaceImplementationMethodSymbol",
				"IteratorFinallyMethodSymbol",
				"MiscSymFactory",
				"NamespaceOrAggregateSymbol",
				"NamespaceSymbol",
				"ParentSymbol",
				"PropertySymbol",
				"Scope",
				"KAID",
				"ACCESS",
				"AggKindEnum",
				"ARRAYMETHOD",
				"SpecCons",
				"Symbol",
				"SymbolExtensions",
				"SymFactory",
				"SymFactoryBase",
				"SYMKIND",
				"SynthAggKind",
				"SymbolLoader",
				"AidContainer",
				"BSYMMGR",
				"symbmask_t",
				"SYMTBL",
				"TransparentIdentifierMemberSymbol",
				"TypeParameterSymbol",
				"UnresolvedAggregateSymbol",
				"VariableSymbol",
				"EXPRARRAYINDEX",
				"EXPRARRINIT",
				"EXPRARRAYLENGTH",
				"EXPRASSIGNMENT",
				"EXPRBINOP",
				"EXPRBLOCK",
				"EXPRBOUNDLAMBDA",
				"EXPRCALL",
				"EXPRCAST",
				"EXPRCLASS",
				"EXPRMULTIGET",
				"EXPRMULTI",
				"EXPRCONCAT",
				"EXPRQUESTIONMARK",
				"EXPRCONSTANT",
				"EXPREVENT",
				"EXPR",
				"ExpressionIterator",
				"EXPRFIELD",
				"EXPRFIELDINFO",
				"EXPRHOISTEDLOCALEXPR",
				"EXPRLIST",
				"EXPRLOCAL",
				"EXPRMEMGRP",
				"EXPRMETHODINFO",
				"EXPRFUNCPTR",
				"EXPRNamedArgumentSpecification",
				"EXPRPROP",
				"EXPRPropertyInfo",
				"EXPRRETURN",
				"EXPRSTMT",
				"EXPRWRAP",
				"EXPRTHISPOINTER",
				"EXPRTYPEARGUMENTS",
				"EXPRTYPEOF",
				"EXPRTYPEORNAMESPACE",
				"EXPRUNARYOP",
				"EXPRUNBOUNDLAMBDA",
				"EXPRUSERDEFINEDCONVERSION",
				"EXPRUSERLOGOP",
				"EXPRZEROINIT",
				"ExpressionTreeRewriter",
				"ExprVisitorBase",
				"AggregateType",
				"ArgumentListType",
				"ArrayType",
				"BoundLambdaType",
				"ErrorType",
				"MethodGroupType",
				"NullableType",
				"NullType",
				"OpenTypePlaceholderType",
				"ParameterModifierType",
				"PointerType",
				"PredefinedTypes",
				"PredefinedTypeFacts",
				"CType",
				"TypeArray",
				"TypeFactory",
				"TypeManager",
				"TypeParameterType",
				"KeyPair`2",
				"TypeTable",
				"VoidType",
				"CError",
				"CParameterizedError",
				"CErrorFactory",
				"ErrorFacts",
				"ErrArgKind",
				"ErrArgFlags",
				"SymWithTypeMemo",
				"MethPropWithInstMemo",
				"ErrArg",
				"ErrArgRef",
				"ErrArgRefOnly",
				"ErrArgNoRef",
				"ErrArgIds",
				"ErrArgSymKind",
				"ErrorHandling",
				"IErrorSink",
				"MessageID",
				"UserStringBuilder",
				"CController",
				"<Cons>d__10`1",
				"<Cons>d__11`1",
				"DynamicProperty",
				"DynamicDebugViewEmptyException",
				"<>c__DisplayClass20_0",
				"ExpressionEXPR",
				"ArgumentObject",
				"NameHashKey",
				"<>c__DisplayClass18_0",
				"<>c__DisplayClass18_1",
				"<>c__DisplayClass43_0",
				"<>c__DisplayClass45_0",
				"KnownName",
				"BinOpArgInfo",
				"BinOpSig",
				"BinOpFullSig",
				"ConversionFunc",
				"ExplicitConversion",
				"PfnBindBinOp",
				"PfnBindUnaOp",
				"GroupToArgsBinder",
				"GroupToArgsBinderResult",
				"ImplicitConversion",
				"UnaOpSig",
				"UnaOpFullSig",
				"OPINFO",
				"<ToEnumerable>d__1",
				"CMethodIterator",
				"NewInferenceResult",
				"Dependency",
				"<InterfaceAndBases>d__0",
				"<AllConstraintInterfaces>d__1",
				"<TypeAndBaseClasses>d__2",
				"<TypeAndBaseClassInterfaces>d__3",
				"<AllPossibleInterfaces>d__4",
				"<Children>d__0",
				"Kind",
				"TypeArrayKey",
				"Key",
				"PredefinedTypeInfo",
				"StdTypeVarColl",
				"<>c__DisplayClass71_0",
				"__StaticArrayInitTypeSize=104",
				"__StaticArrayInitTypeSize=169",
				"SNINativeMethodWrapper",
				"QTypes",
				"ProviderEnum",
				"IOType",
				"ConsumerNumber",
				"SqlAsyncCallbackDelegate",
				"ConsumerInfo",
				"SNI_Error",
				"Win32NativeMethods",
				"NativeOledbWrapper",
				"AdalException",
				"ADALNativeWrapper",
				"Sni_Consumer_Info",
				"SNI_ConnWrapper",
				"SNI_Packet_IOType",
				"ConsumerNum",
				"$ArrayType$$$BY08$$CBG",
				"_GUID",
				"SNI_CLIENT_CONSUMER_INFO",
				"IUnknown",
				"__s_GUID",
				"IChapteredRowset",
				"_FILETIME",
				"ProviderNum",
				"ITransactionLocal",
				"SNI_ERROR",
				"$ArrayType$$$BY08G",
				"BOID",
				"ModuleLoadException",
				"ModuleLoadExceptionHandlerException",
				"ModuleUninitializer",
				"LanguageSupport",
				"gcroot<System::String ^>",
				"$ArrayType$$$BY00Q6MPBXXZ",
				"Progress",
				"$ArrayType$$$BY0A@P6AXXZ",
				"$ArrayType$$$BY0A@P6AHXZ",
				"__enative_startup_state",
				"TriBool",
				"ICLRRuntimeHost",
				"ThisModule",
				"_EXCEPTION_POINTERS",
				"Bid",
				"SqlDependencyProcessDispatcher",
				"BidIdentityAttribute",
				"BidMetaTextAttribute",
				"BidMethodAttribute",
				"BidArgumentTypeAttribute",
				"ExtendedClrTypeCode",
				"ITypedGetters",
				"ITypedGettersV3",
				"ITypedSetters",
				"ITypedSettersV3",
				"MetaDataUtilsSmi",
				"SmiConnection",
				"SmiContext",
				"SmiContextFactory",
				"SmiEventSink",
				"SmiEventSink_Default",
				"SmiEventSink_DeferedProcessing",
				"SmiEventStream",
				"SmiExecuteType",
				"SmiGettersStream",
				"SmiLink",
				"SmiMetaData",
				"SmiExtendedMetaData",
				"SmiParameterMetaData",
				"SmiStorageMetaData",
				"SmiQueryMetaData",
				"SmiRecordBuffer",
				"SmiRequestExecutor",
				"SmiSettersStream",
				"SmiStream",
				"SmiXetterAccessMap",
				"SmiXetterTypeCode",
				"SqlContext",
				"SqlDataRecord",
				"SqlPipe",
				"SqlTriggerContext",
				"ValueUtilsSmi",
				"SqlClientWrapperSmiStream",
				"SqlClientWrapperSmiStreamChars",
				"IBinarySerialize",
				"InvalidUdtException",
				"SqlFacetAttribute",
				"DataAccessKind",
				"SystemDataAccessKind",
				"SqlFunctionAttribute",
				"SqlMetaData",
				"SqlMethodAttribute",
				"FieldInfoEx",
				"BinaryOrderedUdtNormalizer",
				"Normalizer",
				"BooleanNormalizer",
				"SByteNormalizer",
				"ByteNormalizer",
				"ShortNormalizer",
				"UShortNormalizer",
				"IntNormalizer",
				"UIntNormalizer",
				"LongNormalizer",
				"ULongNormalizer",
				"FloatNormalizer",
				"DoubleNormalizer",
				"SqlProcedureAttribute",
				"SerializationHelperSql9",
				"Serializer",
				"NormalizedSerializer",
				"BinarySerializeSerializer",
				"DummyStream",
				"SqlTriggerAttribute",
				"SqlUserDefinedAggregateAttribute",
				"SqlUserDefinedTypeAttribute",
				"TriggerAction",
				"MemoryRecordBuffer",
				"SmiPropertySelector",
				"SmiMetaDataPropertyCollection",
				"SmiMetaDataProperty",
				"SmiUniqueKeyProperty",
				"SmiOrderProperty",
				"SmiDefaultFieldsProperty",
				"SmiTypedGetterSetter",
				"SqlRecordBuffer",
				"BaseTreeIterator",
				"DataDocumentXPathNavigator",
				"DataPointer",
				"DataSetMapper",
				"IXmlDataVirtualNode",
				"BaseRegionIterator",
				"RegionIterator",
				"TreeIterator",
				"ElementState",
				"XmlBoundElement",
				"XmlDataDocument",
				"XmlDataImplementation",
				"XPathNodePointer",
				"AcceptRejectRule",
				"InternalDataCollectionBase",
				"TypedDataSetGenerator",
				"StrongTypingException",
				"TypedDataSetGeneratorException",
				"ColumnTypeConverter",
				"CommandBehavior",
				"CommandType",
				"KeyRestrictionBehavior",
				"ConflictOption",
				"ConnectionState",
				"Constraint",
				"ConstraintCollection",
				"ConstraintConverter",
				"ConstraintEnumerator",
				"ForeignKeyConstraintEnumerator",
				"ChildForeignKeyConstraintEnumerator",
				"ParentForeignKeyConstraintEnumerator",
				"DataColumn",
				"AutoIncrementValue",
				"AutoIncrementInt64",
				"AutoIncrementBigInteger",
				"DataColumnChangeEventArgs",
				"DataColumnChangeEventHandler",
				"DataColumnCollection",
				"DataColumnPropertyDescriptor",
				"DataError",
				"DataException",
				"ConstraintException",
				"DeletedRowInaccessibleException",
				"DuplicateNameException",
				"InRowChangingEventException",
				"InvalidConstraintException",
				"MissingPrimaryKeyException",
				"NoNullAllowedException",
				"ReadOnlyException",
				"RowNotInTableException",
				"VersionNotFoundException",
				"ExceptionBuilder",
				"DataKey",
				"DataRelation",
				"DataRelationCollection",
				"DataRelationPropertyDescriptor",
				"DataRow",
				"DataRowBuilder",
				"DataRowAction",
				"DataRowChangeEventArgs",
				"DataRowChangeEventHandler",
				"DataRowCollection",
				"DataRowCreatedEventHandler",
				"DataSetClearEventhandler",
				"DataRowState",
				"DataRowVersion",
				"DataRowView",
				"SerializationFormat",
				"DataSet",
				"DataSetSchemaImporterExtension",
				"DataSetDateTime",
				"DataSysDescriptionAttribute",
				"DataTable",
				"DataTableClearEventArgs",
				"DataTableClearEventHandler",
				"DataTableCollection",
				"DataTableNewRowEventArgs",
				"DataTableNewRowEventHandler",
				"DataTablePropertyDescriptor",
				"DataTableReader",
				"DataTableReaderListener",
				"DataTableTypeConverter",
				"DataView",
				"DataViewListener",
				"DataViewManager",
				"DataViewManagerListItemTypeDescriptor",
				"DataViewRowState",
				"DataViewSetting",
				"DataViewSettingCollection",
				"DBConcurrencyException",
				"DbType",
				"DefaultValueTypeConverter",
				"FillErrorEventArgs",
				"FillErrorEventHandler",
				"AggregateNode",
				"BinaryNode",
				"LikeNode",
				"ConstNode",
				"DataExpression",
				"ExpressionNode",
				"ExpressionParser",
				"Tokens",
				"OperatorInfo",
				"InvalidExpressionException",
				"EvaluateException",
				"SyntaxErrorException",
				"ExprException",
				"FunctionNode",
				"FunctionId",
				"Function",
				"IFilter",
				"LookupNode",
				"NameNode",
				"UnaryNode",
				"ZeroOpNode",
				"ForeignKeyConstraint",
				"IColumnMapping",
				"IColumnMappingCollection",
				"IDataAdapter",
				"IDataParameter",
				"IDataParameterCollection",
				"IDataReader",
				"IDataRecord",
				"IDbCommand",
				"IDbConnection",
				"IDbDataAdapter",
				"IDbDataParameter",
				"IDbTransaction",
				"IsolationLevel",
				"ITableMapping",
				"ITableMappingCollection",
				"LoadOption",
				"MappingType",
				"MergeFailedEventArgs",
				"MergeFailedEventHandler",
				"Merger",
				"MissingMappingAction",
				"MissingSchemaAction",
				"OperationAbortedException",
				"ParameterDirection",
				"PrimaryKeyTypeConverter",
				"PropertyCollection",
				"RBTreeError",
				"TreeAccessMethod",
				"RBTree`1",
				"RecordManager",
				"StatementCompletedEventArgs",
				"StatementCompletedEventHandler",
				"RelatedView",
				"RelationshipConverter",
				"Rule",
				"SchemaSerializationMode",
				"SchemaType",
				"IndexField",
				"Index",
				"Listeners`1",
				"SimpleType",
				"LocalDBAPI",
				"LocalDBInstanceElement",
				"LocalDBInstancesCollection",
				"LocalDBConfigurationSection",
				"SqlDbType",
				"StateChangeEventArgs",
				"StateChangeEventHandler",
				"StatementType",
				"UniqueConstraint",
				"UpdateRowSource",
				"UpdateStatus",
				"XDRSchema",
				"XmlDataLoader",
				"XMLDiffLoader",
				"XmlReadMode",
				"SchemaFormat",
				"XmlTreeGen",
				"NewDiffgramGen",
				"XmlDataTreeWriter",
				"DataTextWriter",
				"DataTextReader",
				"XMLSchema",
				"ConstraintTable",
				"XSDSchema",
				"XmlIgnoreNamespaceReader",
				"XmlToDatasetMap",
				"XmlWriteMode",
				"SqlEventSource",
				"SqlDataSourceEnumerator",
				"SqlGenericUtil",
				"SqlNotificationRequest",
				"INullable",
				"SqlBinary",
				"SqlBoolean",
				"SqlByte",
				"SqlBytesCharsState",
				"SqlBytes",
				"StreamOnSqlBytes",
				"SqlChars",
				"StreamOnSqlChars",
				"SqlStreamChars",
				"SqlDateTime",
				"SqlDecimal",
				"SqlDouble",
				"SqlFileStream",
				"UnicodeString",
				"SecurityQualityOfService",
				"FileFullEaInformation",
				"SqlGuid",
				"SqlInt16",
				"SqlInt32",
				"SqlInt64",
				"SqlMoney",
				"SQLResource",
				"SqlSingle",
				"SqlCompareOptions",
				"SqlString",
				"SqlTypesSchemaImporterExtensionHelper",
				"TypeCharSchemaImporterExtension",
				"TypeNCharSchemaImporterExtension",
				"TypeVarCharSchemaImporterExtension",
				"TypeNVarCharSchemaImporterExtension",
				"TypeTextSchemaImporterExtension",
				"TypeNTextSchemaImporterExtension",
				"TypeVarBinarySchemaImporterExtension",
				"TypeBinarySchemaImporterExtension",
				"TypeVarImageSchemaImporterExtension",
				"TypeDecimalSchemaImporterExtension",
				"TypeNumericSchemaImporterExtension",
				"TypeBigIntSchemaImporterExtension",
				"TypeIntSchemaImporterExtension",
				"TypeSmallIntSchemaImporterExtension",
				"TypeTinyIntSchemaImporterExtension",
				"TypeBitSchemaImporterExtension",
				"TypeFloatSchemaImporterExtension",
				"TypeRealSchemaImporterExtension",
				"TypeDateTimeSchemaImporterExtension",
				"TypeSmallDateTimeSchemaImporterExtension",
				"TypeMoneySchemaImporterExtension",
				"TypeSmallMoneySchemaImporterExtension",
				"TypeUniqueIdentifierSchemaImporterExtension",
				"EComparison",
				"StorageState",
				"SqlTypeException",
				"SqlNullValueException",
				"SqlTruncateException",
				"SqlNotFilledException",
				"SqlAlreadyFilledException",
				"SQLDebug",
				"SqlXml",
				"SqlXmlStreamWrapper",
				"SqlClientEncryptionAlgorithmFactoryList",
				"SqlSymmetricKeyCache",
				"SqlColumnEncryptionKeyStoreProvider",
				"SqlColumnEncryptionCertificateStoreProvider",
				"SqlColumnEncryptionCngProvider",
				"SqlColumnEncryptionCspProvider",
				"SqlAeadAes256CbcHmac256Algorithm",
				"SqlAeadAes256CbcHmac256Factory",
				"SqlAeadAes256CbcHmac256EncryptionKey",
				"SqlAes256CbcAlgorithm",
				"SqlAes256CbcFactory",
				"SqlClientEncryptionAlgorithm",
				"SqlClientEncryptionAlgorithmFactory",
				"SqlClientEncryptionType",
				"SqlClientSymmetricKey",
				"SqlSecurityUtility",
				"SqlQueryMetadataCache",
				"ApplicationIntent",
				"SqlCredential",
				"SqlConnectionPoolKey",
				"AssemblyCache",
				"OnChangeEventHandler",
				"SqlRowsCopiedEventArgs",
				"SqlRowsCopiedEventHandler",
				"SqlBuffer",
				"_ColumnMapping",
				"Row",
				"BulkCopySimpleResultSet",
				"SqlBulkCopy",
				"SqlBulkCopyColumnMapping",
				"SqlBulkCopyColumnMappingCollection",
				"SqlBulkCopyOptions",
				"SqlCachedBuffer",
				"SqlClientFactory",
				"SqlClientMetaDataCollectionNames",
				"SqlClientPermission",
				"SqlClientPermissionAttribute",
				"SqlCommand",
				"SqlCommandBuilder",
				"SqlCommandSet",
				"SqlConnection",
				"SQLDebugging",
				"ISQLDebug",
				"SqlDebugContext",
				"MEMMAP",
				"SqlConnectionFactory",
				"SqlPerformanceCounters",
				"SqlConnectionPoolGroupProviderInfo",
				"SqlConnectionPoolProviderInfo",
				"SqlConnectionString",
				"SqlConnectionStringBuilder",
				"SqlConnectionTimeoutErrorPhase",
				"SqlConnectionInternalSourceType",
				"SqlConnectionTimeoutPhaseDuration",
				"SqlConnectionTimeoutErrorInternal",
				"SqlDataAdapter",
				"SqlDataReader",
				"SqlDataReaderSmi",
				"SqlDelegatedTransaction",
				"SqlDependency",
				"SqlDependencyPerAppDomainDispatcher",
				"SqlNotification",
				"MetaType",
				"TdsDateTime",
				"SqlError",
				"SqlErrorCollection",
				"SqlException",
				"SqlInfoMessageEventArgs",
				"SqlInfoMessageEventHandler",
				"SqlInternalConnection",
				"SqlInternalConnectionSmi",
				"SessionStateRecord",
				"SessionData",
				"SqlInternalConnectionTds",
				"ServerInfo",
				"TransactionState",
				"TransactionType",
				"SqlInternalTransaction",
				"SqlMetaDataFactory",
				"SqlNotificationEventArgs",
				"SqlNotificationInfo",
				"SqlNotificationSource",
				"SqlNotificationType",
				"DataFeed",
				"StreamDataFeed",
				"TextDataFeed",
				"XmlDataFeed",
				"SqlParameter",
				"SqlParameterCollection",
				"SqlReferenceCollection",
				"SqlRowUpdatedEventArgs",
				"SqlRowUpdatedEventHandler",
				"SqlRowUpdatingEventArgs",
				"SqlRowUpdatingEventHandler",
				"SqlSequentialStream",
				"SqlSequentialStreamSmi",
				"System.Diagnostics.DebuggableAttribute",
				"System.Diagnostics",
				"System.Net.WebClient",
				"System",
				"System.Specialized.Protection"
			};
			return array[Constant_Mutation.rnd.Next(array.Length)];
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000ABE0 File Offset: 0x00008DE0
		private static void FloorReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.IsLdcI4();
					if (flag2)
					{
						bool flag3 = instruction.GetLdcI4Value() < int.MaxValue;
						if (flag3)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Floor", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000ACEC File Offset: 0x00008EEC
		public static void IfInliner(MethodDef method)
		{
			Local local = new Local(method.Module.ImportAsTypeSig(typeof(int)));
			method.Body.Variables.Add(local);
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].IsLdcI4();
				if (flag)
				{
					bool flag2 = Constant_Mutation.CanObfuscateLDCI4(method.Body.Instructions, i);
					if (flag2)
					{
						int num = Constant_Mutation.rnd.Next();
						int num2 = Constant_Mutation.rnd.Next();
						int value = num ^ num2;
						Instruction instruction = OpCodes.Nop.ToInstruction();
						method.Body.Instructions.Insert(i + 1, OpCodes.Stloc_S.ToInstruction(local));
						method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, method.Body.Instructions[i].GetLdcI4Value() - 4));
						method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, value));
						method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, num2));
						method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
						method.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, num));
						method.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, instruction));
						method.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
						method.Body.Instructions.Insert(i + 9, OpCodes.Stloc_S.ToInstruction(local));
						method.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(float))));
						method.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
						method.Body.Instructions.Insert(i + 12, instruction);
						i += 12;
					}
				}
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000AF58 File Offset: 0x00009158
		public static void InlineInteger(MethodDef method)
		{
			Local local = new Local(method.Module.CorLibTypes.String);
			method.Body.Variables.Add(local);
			Local local2 = new Local(method.Module.CorLibTypes.Int32);
			method.Body.Variables.Add(local2);
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].IsLdcI4();
				if (flag)
				{
					bool flag2 = Constant_Mutation.CanObfuscateLDCI4(method.Body.Instructions, i);
					if (flag2)
					{
						bool isGlobalModuleType = method.DeclaringType.IsGlobalModuleType;
						if (isGlobalModuleType)
						{
							break;
						}
						bool flag3 = !method.HasBody;
						if (flag3)
						{
							break;
						}
						IList<Instruction> instructions = method.Body.Instructions;
						bool flag4 = i - 1 > 0;
						if (flag4)
						{
							try
							{
								bool flag5 = instructions[i - 1].OpCode == OpCodes.Callvirt;
								if (flag5)
								{
									bool flag6 = instructions[i + 1].OpCode == OpCodes.Call;
									if (flag6)
									{
										break;
									}
								}
							}
							catch
							{
							}
						}
						bool flag7 = true;
						int num = Constant_Mutation.rnd.Next(0, 2);
						int num2 = num;
						if (num2 != 0)
						{
							if (num2 == 1)
							{
								flag7 = false;
							}
						}
						else
						{
							flag7 = true;
						}
						int ldcI4Value = instructions[i].GetLdcI4Value();
						string s = Constant_Mutation.RandomString(5, "畹畞疲疷疹痲痹痹瘕番畐畞畵畵畲畲蘽蘐藴虜蘞虢謊謁");
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local2));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local2));
						bool flag8 = flag7;
						if (flag8)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
						}
						instructions.Insert(i, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(string).GetMethod("op_Equality", new Type[]
						{
							typeof(string),
							typeof(string)
						}))));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local));
						bool flag9 = flag7;
						if (flag9)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, Constant_Mutation.RandomString(7, "畹畞疲疷疹痲痹痹瘕番畐畞畵畵畲畲蘽蘐藴虜蘞虢謊謁")));
						}
						instructions.Insert(i + 5, Instruction.Create(OpCodes.Brtrue_S, instructions[i + 6]));
						instructions.Insert(i + 7, Instruction.Create(OpCodes.Br_S, instructions[i + 8]));
						instructions.RemoveAt(i + 10);
						i += 10;
					}
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000B2AC File Offset: 0x000094AC
		private static void RoundReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.IsLdcI4();
					if (flag2)
					{
						bool flag3 = instruction.GetLdcI4Value() < int.MaxValue;
						if (flag3)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num + Constant_Mutation.RandomDouble(0.01, 0.5);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Round", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000B3B8 File Offset: 0x000095B8
		private static void SqrtReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.IsLdcI4();
					if (flag2)
					{
						bool flag3 = instruction.GetLdcI4Value() < int.MaxValue;
						if (flag3)
						{
							bool flag4 = (int)instruction.Operand > 1;
							if (flag4)
							{
								int num = (int)instruction.Operand;
								double num2 = (double)num * (double)num;
								instruction.OpCode = OpCodes.Ldc_R8;
								instruction.Operand = num2;
								method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Sqrt", new Type[]
								{
									typeof(double)
								}))));
								method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000B4CC File Offset: 0x000096CC
		private static void CeilingReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.IsLdcI4();
					if (flag2)
					{
						bool flag3 = instruction.GetLdcI4Value() < int.MaxValue;
						if (flag3)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num - 1.0 + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Ceiling", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000B5E4 File Offset: 0x000097E4
		private static void CeilingReplacer1(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.OpCode == OpCodes.Ldc_R4;
					if (flag2)
					{
						bool flag3 = (int)instruction.Operand < int.MaxValue;
						if (flag3)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num - 1.0 + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Ceiling", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400003D RID: 61
		private static Random rnd = new Random();

		// Token: 0x0400003E RID: 62
		public static List<Instruction> instr = new List<Instruction>();

		// Token: 0x0400003F RID: 63
		public static int[] rndsizevalues = new int[]
		{
			9460301,
			3,
			4,
			65535,
			184,
			0
		};

		// Token: 0x04000040 RID: 64
		public static Dictionary<int, Tuple<TypeDef, int>> Dick = new Dictionary<int, Tuple<TypeDef, int>>();

		// Token: 0x04000041 RID: 65
		private static int abc = 0;
	}
}
