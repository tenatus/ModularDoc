﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Threading;
using System.Linq;
using MarkDoc.Members;
using MarkDoc.Helpers;
using static MarkDoc.Documentation.ITag;

namespace MarkDoc.Documentation.Xml
{
  public class DocElement
    : IDocElement
  {
    #region Properties

    /// <inheritdoc />
    public IDocumentation Documentation { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public Lazy<IReadOnlyDictionary<string, IDocMember>> Members { get; }

    #endregion

    public DocElement(string name, XElement source, DocResolver docResolver, IResolver typeResolver)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      Name = name;
      Documentation = new DocumentationContent(source);
      Members = new Lazy<IReadOnlyDictionary<string, IDocMember>>(() => RetreiveMembers(docResolver, typeResolver), LazyThreadSafetyMode.ExecutionAndPublication);
    }

    private IReadOnlyDictionary<string, IDocMember> RetreiveMembers(DocResolver docResolver, IResolver typeResolver)
    {
      if (!docResolver.TryFindType(Name, out var _, out var memberDocs) || memberDocs == null)
        return new Dictionary<string, IDocMember>();

      void Process(Dictionary<string, Dictionary<TagType, List<ITag>>> cache, IInterface type, string[] names)
      {
        foreach (var name in names)
        {
          var except = new HashSet<TagType>(cache[name].Select(x => x.Key));
          var tags = memberDocs[name].Documentation.Tags.Where(x => x.Key != TagType.Inheritdoc && !except.Contains(x.Key));
          foreach (var tag in tags)
            cache[name].Add(tag.Key, tag.Value.ToList());
        }

        var baseClass = (type is IClass classDef && classDef.BaseClass?.Reference.Value != null)
          ? new[] { classDef.BaseClass.Reference.Value }
          : Enumerable.Empty<IType>();

        var sources = type.InheritedInterfaces
          .Select(x => x.Reference.Value)
          .WhereNotNull()
          .Concat(baseClass)
          .OfType<IInterface>()
          .ToDictionary(x => x.RawName);

        foreach (var source in sources)
        {
          if (!docResolver.TryFindType(source.Value, out var sourceType) || sourceType == null)
            continue;

          var members = sourceType.Members.Value;
          foreach (var name in names)
          {
            if (!members.TryGetValue(name, out var member))
              continue;

            var documentation = member.Documentation;
            var except = new HashSet<TagType>(cache[name].Select(x => x.Key));
            var tags = documentation.Tags.Where(x => x.Key != TagType.Inheritdoc && !except.Contains(x.Key));
            foreach (var tag in tags)
              cache[name].Add(tag.Key, tag.Value.ToList());
          }
        }
      }

      var result = new Dictionary<string, IReadOnlyDictionary<TagType, IReadOnlyCollection<ITag>>>(memberDocs.Count);
      foreach (var item in memberDocs.GroupBy(x => x.Value.Documentation.HasInheritDoc))
      {
        if (item.Key && typeResolver.TryFindType(Name, out var type) && type is IInterface interfaceDef)
        {
          var temps = new Dictionary<string, Dictionary<TagType, List<ITag>>>(item.ToDictionary(x => x.Key, x => new Dictionary<TagType, List<ITag>>()));
          Process(temps, interfaceDef, temps.Select(x => x.Key).ToArray());

          // Cache collected documentation
          foreach (var temp in temps)
            result.Add(temp.Key, temp.Value.ToDictionary(x => x.Key, x => x.Value.ToReadOnlyCollection()));
        }
        else
          foreach (var member in item.Select(Linq.XtoX))
            result.Add(member.Key, member.Value.Documentation.Tags);
      }

      IEnumerable<IDocMember> ProcessCache(IReadOnlyDictionary<string, IReadOnlyDictionary<TagType, IReadOnlyCollection<ITag>>> cache)
      {
        foreach (var item in cache)
        {
          var member = memberDocs[item.Key];

          yield return new DocMember(member.Name, member.Type, new DocumentationContent(item.Value));
        }
      }

      return ProcessCache(result).ToDictionary(x => x.Name);
    }
  }
}
