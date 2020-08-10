﻿using dnlib.DotNet;
using MarkDoc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkDoc.Members.Dnlib
{
  public static class GenericsHelper
  {
    public static IReadOnlyDictionary<string, string> ResolveMethodGenerics(this MethodDef source)
    {
      static IEnumerable<(string type, string name)> ResolveParentTypeGenerics(MethodDef source)
        => GetGenericArguments(source.DeclaringType)
            .DistinctBy(x => x.Name)
            .Select((x, i) => (x.Name.String, $"`{i}"));

      static IEnumerable<(string type, string name)> ResolveTypeGenerics(MethodDef source)
        => source.GenericParameters.Select((x, i) => (x.Name.String, $"``{i}"));

      if (source is null)
        throw new ArgumentNullException(nameof(source));

      var outerArgs = ResolveParentTypeGenerics(source);
      var thisArgs = ResolveTypeGenerics(source);

      return outerArgs.Concat(thisArgs).ToDictionary(x => x.type, x => x.name);
    }

    public static IReadOnlyDictionary<string, string> ResolvePropertyGenerics(this PropertyDef source, IReadOnlyCollection<MethodDef> methods)
    {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      var outerArgs = GetGenericArguments(source.DeclaringType)
        .DistinctBy(x => x.Name)
        .Select((x, i) => new { Type = x.Name, Name = $"`{i}" });
      var thisArgs = methods.Select(x => x.GenericParameters)
        .SelectMany(Linq.XtoX)
        .DistinctBy(x => x.Name)
        .Select((x, i) => new { Type = x.Name, Name = $"``{i}" });
      return outerArgs.Concat(thisArgs).ToDictionary(x => x.Type.String, x => x.Name);
    }

    public static IReadOnlyDictionary<string, string> ResolveTypeGenerics(this TypeDef source)
    {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      return GetGenericArguments(source.DeclaringType)
        .DistinctBy(x => x.Name)
        .Select((x, i) => new { Type = x.Name, Name = $"`{i}" })
        .ToDictionary(x => x.Type.String, x => x.Name);
    }

    private static IEnumerable<GenericParam> GetGenericArguments(TypeDef? type)
    {
      if (type is null)
        yield break;

      foreach (var parameter in GetGenericArguments(type.DeclaringType))
        yield return parameter;
      foreach (var parameter in type.GenericParameters)
        yield return parameter;
    }
  }
}