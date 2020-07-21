﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkDoc.Helpers;

namespace MarkDoc.Elements.Markdown
{
  public class Table
    : BaseElement, ITable
  {
    #region Constants

    private const string DEL_VERTICAL = "|";
    private const string DEL_HORIZONTAL = "-";

    #endregion

    #region Properties

    /// <inheritdoc />
    public string Heading { get; }

    /// <inheritdoc />
    public int Level { get; }

    /// <inheritdoc />
    public IReadOnlyCollection<IText> Headings { get; }

    /// <inheritdoc />
    public IReadOnlyCollection<IReadOnlyCollection<IElement>> Content { get; }

    #endregion

    public Table(IEnumerable<IText> headings, IEnumerable<IReadOnlyCollection<IElement>> content, string heading = "", int level = 0)
    {
      Headings = headings.ToReadOnlyCollection();
      Content = content.ToReadOnlyCollection();
      Heading = heading;
      Level = level;
    }

    /// <inheritdoc />
    public override string ToString()
    {
      var result = new StringBuilder();
      var count = 0;

      if (!string.IsNullOrEmpty(Heading))
        result.AppendLine(Heading.ToHeading(Level));

      // Column headers
      result.Append(DEL_VERTICAL);
      foreach (var heading in Headings)
      {
        count++;
        result.Append(" ").Append(heading.ToString()).Append(" ").Append(DEL_VERTICAL);
      }

      // Horizontal line
      result.Append("\n").Append(DEL_VERTICAL);
      for (var i = 0; i < count; i++)
        result.Append(" ")
          .Append(DEL_HORIZONTAL)
          .Append(DEL_HORIZONTAL)
          .Append(DEL_HORIZONTAL)
          .Append(" ")
          .Append(DEL_VERTICAL);

      foreach (var row in Content)
      {
        result.Append(Environment.NewLine).Append(DEL_VERTICAL);

        var colCount = 0;
        foreach (var item in row.Take(count))
        {
          colCount++;
          result.Append(" ").Append(item.ToString().ReplaceNewline()).Append(" ").Append(DEL_VERTICAL);
        }

        if (count > colCount)
          for (int i = 0; i < count - colCount; i++)
            result.Append("   ").Append(DEL_VERTICAL);
      }

      return result.ToString();
    }

    /// <inheritdoc />
    public override IEnumerable<string> Print()
    {
      var count = 0;

      if (!string.IsNullOrEmpty(Heading))
      {
        yield return Heading.ToHeading(Level);
        yield return Environment.NewLine;
      }

      // Column headers
      yield return DEL_VERTICAL;
      foreach (var heading in Headings)
      {
        count++;
        yield return " ";
        foreach (var line in heading.Print())
          yield return line;
        yield return $" {DEL_VERTICAL}";
      }

      // Horizontal line
      yield return Environment.NewLine;
      yield return DEL_VERTICAL;
      for (var i = 0; i < count; i++)
        yield return $" {DEL_HORIZONTAL}{DEL_HORIZONTAL}{DEL_HORIZONTAL} {DEL_VERTICAL}";

      foreach (var row in Content)
      {
        yield return Environment.NewLine;
        yield return DEL_VERTICAL;

        var colCount = 0;
        foreach (var item in row.Take(count))
        {
          colCount++;
          yield return " ";
          foreach (var line in item.Print())
            yield return line.ReplaceNewline();
          yield return $" {DEL_VERTICAL}";
        }

        if (count > colCount)
          for (var i = 0; i < count - colCount; i++)
          {
            yield return "   ";
            yield return DEL_VERTICAL;
          }
      }

      yield return Environment.NewLine;
    }
  }
}
