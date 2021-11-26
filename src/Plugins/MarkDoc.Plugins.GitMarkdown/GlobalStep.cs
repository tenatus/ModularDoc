﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MarkDoc.Core;
using MarkDoc.MVVM.Helpers;

namespace MarkDoc.Plugins.GitMarkdown
{
  public sealed class GlobalStep
    : BasePluginStep
  {
    /// <inheritdoc />
    public override string Id => "12452BF9-2863-4AB6-8742-056F124CE409";

    /// <inheritdoc />
    public override string Name => "Global step";

    /// <inheritdoc />
    public override int StepNumber => 4;

    /// <inheritdoc />
    public override bool IsLastStep => true;

    /// <inheritdoc />
    public override async Task<IStepView<IStepViewModel>> GetStepView(IReadOnlyDictionary<string, string> settings,
      IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> previousSettings)
    {
      var view = TypeResolver.Resolve<IStepView<IStepViewModel<IGlobalSettings>, IGlobalSettings>>();
      await view.SetNamedArguments(settings);
      view.SetPreviousSettings(previousSettings);

      return view;
    }

    /// <inheritdoc />
    public override string GetViewId()
    {
      var view = TypeResolver.Resolve<IStepView<IStepViewModel<IGlobalSettings>, IGlobalSettings>>();
      return view.Id;
    }
  }
}