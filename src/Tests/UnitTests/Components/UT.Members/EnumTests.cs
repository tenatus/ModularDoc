﻿using MarkDoc.Members.Enums;
using MarkDoc.Members.Types;
using MarkDoc.Members;
using UT.Members.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace UT.Members
{
  public class EnumTests
  {
    #region Data providers

    private static IEnumerable<object[]> GetEnumNames()
    {
      var data = new[]
      {
        Constants.PUBLIC_ENUM,
        Constants.INTERNAL_ENUM,
        Constants.PUBLIC_NESTED_ENUM,
        Constants.PROTECTED_NESTED_ENUM,
        Constants.INTERNAL_NESTED_ENUM,
      };

      foreach (var name in data)
        foreach (var resolver in new ResolversProvider())
          yield return new[] { resolver.First(), name };
    }

    private static IEnumerable<object[]> GetEnumAccessorsData()
    {
      var data = new[]
      {
        (Constants.PUBLIC_ENUM, AccessorType.Public),
        (Constants.INTERNAL_ENUM, AccessorType.Internal),
        (Constants.PUBLIC_NESTED_ENUM, AccessorType.Public),
        (Constants.PROTECTED_NESTED_ENUM, AccessorType.Protected),
        (Constants.INTERNAL_NESTED_ENUM, AccessorType.Internal),
      };

      foreach (var (name, accessor) in data)
        foreach (var resolver in new ResolversProvider())
          yield return new[] { resolver.First(), name, accessor };
    }

    private static IEnumerable<object[]> GetEnumFieldsData()
    {
      var data = new[]
      {
        Constants.PUBLIC_ENUM,
        Constants.INTERNAL_ENUM,
        Constants.PUBLIC_NESTED_ENUM,
        Constants.PROTECTED_NESTED_ENUM,
        Constants.INTERNAL_NESTED_ENUM,
      };

      var fields = new[] { "FieldA", "FieldB" };
      foreach (var name in data)
        foreach (var resolver in new ResolversProvider())
          yield return new[] { resolver.First(), name, fields };
    }

    private static IEnumerable<object[]> GetEnumNamespaceData()
    {
      const string enumNameSpace = "TestLibrary.Enums";
      var data = new[]
      {
        (Constants.PUBLIC_ENUM, enumNameSpace),
        (Constants.INTERNAL_ENUM, enumNameSpace),
        (Constants.PUBLIC_NESTED_ENUM, $"{enumNameSpace}.EnumParent"),
        (Constants.PROTECTED_NESTED_ENUM, $"{enumNameSpace}.EnumParent"),
        (Constants.INTERNAL_NESTED_ENUM, $"{enumNameSpace}.EnumParent"),
      };

      foreach (var (name, space) in data)
        foreach (var resolver in new ResolversProvider())
          yield return new[] { resolver.First(), name, space };
    }

    #endregion

    private static IEnum? GetEnum(IResolver resolver, string name)
    {
      resolver.Resolve(Constants.TEST_ASSEMBLY);

      return resolver
        .GetTypes<IEnum>()
        .FirstOrDefault(type => type.Name.Equals(name));
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNames))]
    public void ValidateEnumNames(IResolver resolver, string name)
    {
      var query = GetEnum(resolver, name);

      Assert.NotNull(query);
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumAccessorsData))]
    public void ValidateEnumAccessors(IResolver resolver, string name, AccessorType accessor)
    {
      var query = GetEnum(resolver, name);

      Assert.True(query?.Accessor == accessor, $"{resolver.GetType().FullName}: The '{name}' accessor type is invalid. Expected '{accessor}' != Actual '{query?.Accessor}'");
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumFieldsData))]
    public void ValidateEnumFieldNames(IResolver resolver, string name, string[] fields)
    {
      var query = GetEnum(resolver, name);

      Assert.Equal(query?.Fields.Select(field => field.Name), fields);
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNamespaceData))]
    public void ValidateEnumNamespace(IResolver resolver, string name, string expectedNamespace)
    {
      var query = GetEnum(resolver, name);

      Assert.True(query?.TypeNamespace.Equals(expectedNamespace), $"{resolver.GetType().FullName}: The '{name}' namespace is invalid. Expected '{expectedNamespace}' != Actual '{query?.TypeNamespace}'.");
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNamespaceData))]
    public void ValidateEnumRawName(IResolver resolver, string name, string expectedNamespace)
    {
      var query = GetEnum(resolver, name);

      Assert.True(query?.RawName.Equals($"{expectedNamespace}.{name}"), $"{resolver.GetType().FullName}: The '{name}' raw name is invalid. Expected '{expectedNamespace}.{name}' != Actual '{query?.RawName}'.");
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNamespaceData))]
    public void ValidateEnumFieldRawName(IResolver resolver, string name, string expectedNamespace)
    {
      var query = GetEnum(resolver, name);

      var fieldA = $"{expectedNamespace}.{name} {expectedNamespace}.{name}.FieldA";
      Assert.False(query?.Fields.FirstOrDefault(field => field.RawName.Equals(fieldA)) == null, $"{resolver.GetType().FullName}: The '{name}' field raw names are invalid. Expected '{fieldA}' != Actual '{query?.Fields.First(field => field.Name.Equals("FieldA")).RawName}'.");
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNames))]
    public void ValidateEnumFieldIsPublic(IResolver resolver, string name)
    {
      var query = GetEnum(resolver, name);

      Assert.True(query?.Fields.Select(field => field.Accessor != AccessorType.Public).Any(), $"{resolver.GetType().FullName}: The '{name}' fields are invalid. All fields must be public.");
    }

    [Theory]
    [Category(nameof(IEnum))]
    [MemberData(nameof(GetEnumNames))]
    public void ValidateEnumFieldIsStatic(IResolver resolver, string name)
    {
      var query = GetEnum(resolver, name);

      Assert.True(query?.Fields.Select(field => field.IsStatic).Any(), $"{resolver.GetType().FullName}: The '{name}' fields are invalid. All fields must be static.");
    }
  }
}
