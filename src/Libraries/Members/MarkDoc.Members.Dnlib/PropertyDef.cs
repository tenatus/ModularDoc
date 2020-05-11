﻿using MarkDoc.Members.Enums;
using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using MarkDoc.Members.Dnlib.Properties;
using System.Collections.Generic;
using dnlib.DotNet;
using MarkDoc.Helpers;

namespace MarkDoc.Members.Dnlib
{
  [DebuggerDisplay(nameof(PropertyDef) + ": {Name}")]
  public class PropertyDef
    : MemberDef, IProperty
  {
    #region Properties

    /// <inheritdoc />
    public override string Name { get; }

    /// <inheritdoc />
    public override bool IsStatic { get; }

    /// <inheritdoc />
    public MemberInheritance Inheritance { get; }

    /// <inheritdoc />
    public IResType Type { get; }

    /// <inheritdoc />
    public override AccessorType Accessor { get; }

    /// <inheritdoc />
    public AccessorType? GetAccessor { get; }

    /// <inheritdoc />
    public AccessorType? SetAccessor { get; }

    public override string RawName { get; }

    #endregion

    /// <summary>
    /// Default constructor
    /// </summary>
    private PropertyDef(IResolver resolver, dnlib.DotNet.PropertyDef source, dnlib.DotNet.MethodDef[] methods)
      : base(resolver, source)
    {
      var generics = source.ResolvePropertyGenerics(methods);
      Name = source.Name;
      RawName = $"P:{source.FullName}";
      IsStatic = methods.First().IsStatic;
      Type = Resolver.Resolve(ResolveType(source), generics);
      Inheritance = ResolveInheritance(methods);
      Accessor = ResolveAccessor(methods);
      GetAccessor = ResolveAccessor(source.GetMethod);
      SetAccessor = ResolveAccessor(source.SetMethod);
    }

    #region Methods

    internal static PropertyDef? Initialize(IResolver resolver, dnlib.DotNet.PropertyDef source)
    {
      var methods = source.SetMethods.Concat(source.GetMethods).Where(x => !x.IsPrivate).ToArray();

      if (methods.Length == 0)
        return null;
      return new PropertyDef(resolver, source, methods);
    }

    private static dnlib.DotNet.TypeSig ResolveType(dnlib.DotNet.PropertyDef source)
    {
      if (source.GetMethod != null)
        return source.GetMethod.ReturnType;
      else if (source.SetMethod != null)
        return source.SetMethod.Parameters.First().Type;

      throw new NotSupportedException(Resources.notProperty);
    }

    private static AccessorType? ResolveAccessor(dnlib.DotNet.MethodDef? method)
    {
      if (method == null)
        return null;

      if (method.Access == dnlib.DotNet.MethodAttributes.Public)
        return AccessorType.Public;
      if (method.Access == dnlib.DotNet.MethodAttributes.Family)
        return AccessorType.Protected;
      return AccessorType.Internal;
    }

    private static AccessorType ResolveAccessor(dnlib.DotNet.MethodDef[] methods)
    {
      if (methods.Length == 1)
        return ResolveAccessor(methods[0]) ?? throw new Exception(Resources.accessorNull);

      var accessors = methods.Select(x => ResolveAccessor(x)).ToArray();

      if (accessors.Any(x => x.Equals(AccessorType.Public)))
        return AccessorType.Public;
      if (accessors.Any(x => x.Equals(AccessorType.Protected)))
        return AccessorType.Protected;
      if (accessors.Any(x => x.Equals(AccessorType.Internal)))
        return AccessorType.Internal;

      throw new NotSupportedException(Resources.accessorTypeInvalid);
    }

    private static MemberInheritance ResolveInheritance(dnlib.DotNet.MethodDef[] methods)
    {
      var method = methods.First();
      if (method.IsVirtual && (method.Attributes & dnlib.DotNet.MethodAttributes.NewSlot) == 0)
        return MemberInheritance.Override;
      else if (method.IsVirtual)
        return MemberInheritance.Virtual;
      else if (method.IsAbstract)
        return MemberInheritance.Abstract;

      return MemberInheritance.Normal;
    } 

    #endregion
  }
}
