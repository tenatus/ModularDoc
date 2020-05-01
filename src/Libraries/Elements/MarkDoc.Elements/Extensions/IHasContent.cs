﻿namespace MarkDoc.Elements.Extensions
{
  /// <summary>
  /// Interface for elements which have content
  /// </summary>
  /// <typeparam name="T">Content type</typeparam>
  public interface IHasContent<T>
  {
    T Content { get; set; }  
  }
}