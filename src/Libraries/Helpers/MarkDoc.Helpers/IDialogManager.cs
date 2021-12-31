﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MarkDoc.Core;

namespace MarkDoc.Helpers
{
  /// <summary>
  /// Interface for dialog managers
  /// </summary>
  public interface IDialogManager
  {
    public enum DialogButtons
    {
      None,
      Yes,
      YesNo,
      YesNoCancel,
      Ok,
      OkCancel,
      Cancel
    }

    /// <summary>
    /// Attempts to select file(s)
    /// </summary>
    /// <param name="title">Dialog title</param>
    /// <param name="filters">File selection filters</param>
    /// <param name="multiselect">Allow multi-selection</param>
    /// <returns>Selection result</returns>
    ValueTask<Option<IReadOnlyCollection<string>>> TrySelectFilesAsync(string title, IEnumerable<(IEnumerable<string> extensions, string description)> filters, bool multiselect = false);

    /// <summary>
    /// Attempts to select a folder
    /// </summary>
    /// <param name="title">Dialog title</param>
    /// <returns>Selection result</returns>
    ValueTask<Option<string>> TrySelectFolderAsync(string title);

    /// <summary>
    /// Displays a dialog with a given <typeparamref name="TView"/>
    /// </summary>
    /// <typeparam name="TView">View type</typeparam>
    /// <returns>True if pressed ok</returns>
    ValueTask<bool> ShowDialogAsync<TView>(IReadOnlyDictionary<string, string>? arguments = default, DialogButtons buttons = DialogButtons.OkCancel) where TView : IDialogView;
  }
}
