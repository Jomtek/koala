using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Blink_Obfuscator_1._0.Protections
{
	// Token: 0x02000024 RID: 36
	internal class InjectHelper1
	{
		// Token: 0x02000025 RID: 37
		public static class InjectHelper
		{
			// Token: 0x0600009A RID: 154 RVA: 0x0000CE44 File Offset: 0x0000B044
			private static TypeDefUser Clone(TypeDef origin)
			{
				TypeDefUser typeDefUser = new TypeDefUser(origin.Namespace, origin.Name);
				typeDefUser.Attributes = origin.Attributes;
				bool flag = origin.ClassLayout != null;
				if (flag)
				{
					typeDefUser.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
				}
				foreach (GenericParam genericParam in origin.GenericParameters)
				{
					typeDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
				}
				return typeDefUser;
			}

			// Token: 0x0600009B RID: 155 RVA: 0x0000CF04 File Offset: 0x0000B104
			private static MethodDefUser Clone(MethodDef origin)
			{
				MethodDefUser methodDefUser = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
				foreach (GenericParam genericParam in origin.GenericParameters)
				{
					methodDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
				}
				return methodDefUser;
			}

			// Token: 0x0600009C RID: 156 RVA: 0x0000CF94 File Offset: 0x0000B194
			private static FieldDefUser Clone(FieldDef origin)
			{
				return new FieldDefUser(origin.Name, null, origin.Attributes);
			}

			// Token: 0x0600009D RID: 157 RVA: 0x0000CFBC File Offset: 0x0000B1BC
			private static TypeDef PopulateContext(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				IDnlibDef dnlibDef;
				bool flag = !ctx.Map.TryGetValue(typeDef, out dnlibDef);
				TypeDef typeDef2;
				if (flag)
				{
					typeDef2 = InjectHelper1.InjectHelper.Clone(typeDef);
					ctx.Map[typeDef] = typeDef2;
				}
				else
				{
					typeDef2 = (TypeDef)dnlibDef;
				}
				foreach (TypeDef typeDef3 in typeDef.NestedTypes)
				{
					typeDef2.NestedTypes.Add(InjectHelper1.InjectHelper.PopulateContext(typeDef3, ctx));
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					typeDef2.Methods.Add((MethodDef)(ctx.Map[methodDef] = InjectHelper1.InjectHelper.Clone(methodDef)));
				}
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					typeDef2.Fields.Add((FieldDef)(ctx.Map[fieldDef] = InjectHelper1.InjectHelper.Clone(fieldDef)));
				}
				return typeDef2;
			}

			// Token: 0x0600009E RID: 158 RVA: 0x0000D128 File Offset: 0x0000B328
			private static void CopyTypeDef(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				TypeDef typeDef2 = (TypeDef)ctx.Map[typeDef];
				typeDef2.BaseType = (ITypeDefOrRef)ctx.Importer.Import(typeDef.BaseType);
				foreach (InterfaceImpl interfaceImpl in typeDef.Interfaces)
				{
					typeDef2.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef)ctx.Importer.Import(interfaceImpl.Interface)));
				}
			}

			// Token: 0x0600009F RID: 159 RVA: 0x0000D1D0 File Offset: 0x0000B3D0
			private static void CopyMethodDef(MethodDef methodDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				MethodDef methodDef2 = (MethodDef)ctx.Map[methodDef];
				methodDef2.Signature = ctx.Importer.Import(methodDef.Signature);
				methodDef2.Parameters.UpdateParameterTypes();
				bool flag = methodDef.ImplMap != null;
				if (flag)
				{
					methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.TargetModule, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
				}
				foreach (CustomAttribute customAttribute in methodDef.CustomAttributes)
				{
					methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.Importer.Import(customAttribute.Constructor)));
				}
				bool hasBody = methodDef.HasBody;
				if (hasBody)
				{
					methodDef2.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
					methodDef2.Body.MaxStack = methodDef.Body.MaxStack;
					Dictionary<object, object> bodyMap = new Dictionary<object, object>();
					foreach (Local local in methodDef.Body.Variables)
					{
						Local local2 = new Local(ctx.Importer.Import(local.Type));
						methodDef2.Body.Variables.Add(local2);
						local2.Name = local.Name;
						local2.PdbAttributes = local.PdbAttributes;
						bodyMap[local] = local2;
					}
					foreach (Instruction instruction in methodDef.Body.Instructions)
					{
						Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand);
						instruction2.SequencePoint = instruction.SequencePoint;
						bool flag2 = instruction2.Operand is IType;
						if (flag2)
						{
							instruction2.Operand = ctx.Importer.Import((IType)instruction2.Operand);
						}
						else
						{
							bool flag3 = instruction2.Operand is IMethod;
							if (flag3)
							{
								instruction2.Operand = ctx.Importer.Import((IMethod)instruction2.Operand);
							}
							else
							{
								bool flag4 = instruction2.Operand is IField;
								if (flag4)
								{
									instruction2.Operand = ctx.Importer.Import((IField)instruction2.Operand);
								}
							}
						}
						methodDef2.Body.Instructions.Add(instruction2);
						bodyMap[instruction] = instruction2;
					}
					Func<Instruction, Instruction> <>9__0;
					foreach (Instruction instruction3 in methodDef2.Body.Instructions)
					{
						bool flag5 = instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand);
						if (flag5)
						{
							instruction3.Operand = bodyMap[instruction3.Operand];
						}
						else
						{
							bool flag6 = instruction3.Operand is Instruction[];
							if (flag6)
							{
								Instruction instruction4 = instruction3;
								IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
								Func<Instruction, Instruction> selector;
								if ((selector = <>9__0) == null)
								{
									selector = (<>9__0 = ((Instruction target) => (Instruction)bodyMap[target]));
								}
								instruction4.Operand = source.Select(selector).ToArray<Instruction>();
							}
						}
					}
					foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
					{
						methodDef2.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
						{
							CatchType = ((exceptionHandler.CatchType == null) ? null : ((ITypeDefOrRef)ctx.Importer.Import(exceptionHandler.CatchType))),
							TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
							TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
							HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
							HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
							FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
						});
					}
					methodDef2.Body.SimplifyMacros(methodDef2.Parameters);
				}
			}

			// Token: 0x060000A0 RID: 160 RVA: 0x0000D764 File Offset: 0x0000B964
			private static void CopyFieldDef(FieldDef fieldDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				FieldDef fieldDef2 = (FieldDef)ctx.Map[fieldDef];
				fieldDef2.Signature = ctx.Importer.Import(fieldDef.Signature);
			}

			// Token: 0x060000A1 RID: 161 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
			private static void Copy(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx, bool copySelf)
			{
				if (copySelf)
				{
					InjectHelper1.InjectHelper.CopyTypeDef(typeDef, ctx);
				}
				foreach (TypeDef typeDef2 in typeDef.NestedTypes)
				{
					InjectHelper1.InjectHelper.Copy(typeDef2, ctx, true);
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					InjectHelper1.InjectHelper.CopyMethodDef(methodDef, ctx);
				}
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					InjectHelper1.InjectHelper.CopyFieldDef(fieldDef, ctx);
				}
			}

			// Token: 0x060000A2 RID: 162 RVA: 0x0000D888 File Offset: 0x0000BA88
			public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(typeDef.Module, target);
				InjectHelper1.InjectHelper.PopulateContext(typeDef, injectContext);
				InjectHelper1.InjectHelper.Copy(typeDef, injectContext, true);
				return (TypeDef)injectContext.Map[typeDef];
			}

			// Token: 0x060000A3 RID: 163 RVA: 0x0000D8CC File Offset: 0x0000BACC
			public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(methodDef.Module, target);
				injectContext.Map[methodDef] = InjectHelper1.InjectHelper.Clone(methodDef);
				InjectHelper1.InjectHelper.CopyMethodDef(methodDef, injectContext);
				return (MethodDef)injectContext.Map[methodDef];
			}

			// Token: 0x060000A4 RID: 164 RVA: 0x0000D918 File Offset: 0x0000BB18
			public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(typeDef.Module, target);
				injectContext.Map[typeDef] = newType;
				InjectHelper1.InjectHelper.PopulateContext(typeDef, injectContext);
				InjectHelper1.InjectHelper.Copy(typeDef, injectContext, false);
				return injectContext.Map.Values.Except(new TypeDef[]
				{
					newType
				});
			}

			// Token: 0x02000026 RID: 38
			private class InjectContext : ImportResolver
			{
				// Token: 0x060000A5 RID: 165 RVA: 0x0000228E File Offset: 0x0000048E
				public InjectContext(ModuleDef module, ModuleDef target)
				{
					this.OriginModule = module;
					this.TargetModule = target;
					this.importer = new Importer(target, ImporterOptions.TryToUseTypeDefs);
					this.importer.Resolver = this;
				}

				// Token: 0x17000002 RID: 2
				// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000D970 File Offset: 0x0000BB70
				public Importer Importer
				{
					get
					{
						return this.importer;
					}
				}

				// Token: 0x060000A7 RID: 167 RVA: 0x0000D988 File Offset: 0x0000BB88
				public override TypeDef Resolve(TypeDef typeDef)
				{
					bool flag = this.Map.ContainsKey(typeDef);
					TypeDef result;
					if (flag)
					{
						result = (TypeDef)this.Map[typeDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x060000A8 RID: 168 RVA: 0x0000D9C0 File Offset: 0x0000BBC0
				public override MethodDef Resolve(MethodDef methodDef)
				{
					bool flag = this.Map.ContainsKey(methodDef);
					MethodDef result;
					if (flag)
					{
						result = (MethodDef)this.Map[methodDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x060000A9 RID: 169 RVA: 0x0000D9F8 File Offset: 0x0000BBF8
				public override FieldDef Resolve(FieldDef fieldDef)
				{
					bool flag = this.Map.ContainsKey(fieldDef);
					FieldDef result;
					if (flag)
					{
						result = (FieldDef)this.Map[fieldDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x04000051 RID: 81
				public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

				// Token: 0x04000052 RID: 82
				public readonly ModuleDef OriginModule;

				// Token: 0x04000053 RID: 83
				public readonly ModuleDef TargetModule;

				// Token: 0x04000054 RID: 84
				private readonly Importer importer;
			}
		}
	}
}
