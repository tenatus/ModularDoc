﻿namespace ModularDoc.Linker.Markdown

open ModularDoc.Members.Types
open System
open System.Collections.Generic

module private Link =
  let private processTarget (source: string) (target: string) =
    // If the linker source is equal to the target..
    if source.Equals(target, StringComparison.OrdinalIgnoreCase) then
      // return "." for a relative link to the current folder
      "."
    // Otherwise..
    else
      // Splits a path into parts
      let split (input: string) =
        input.Split("/", StringSplitOptions.RemoveEmptyEntries)

      // Split the source path into parts
      let foldersSource = split source
      // Split the target path into parts
      let foldersTarget = split target

      // Find the first part which doesn't match
      let index =
        seq [
          for i in 0 .. min foldersSource.Length foldersTarget.Length - 1 do
            yield foldersSource.[i].Equals(foldersTarget.[i], StringComparison.Ordinal)
        ]
        |> Seq.tryFindIndex not
        |> Option.defaultWith (fun () -> min foldersSource.Length foldersTarget.Length)
        
      if foldersSource.Length = foldersTarget.Length && index = foldersSource.Length - 1 then
        "./" + foldersTarget.[index]
      else if foldersSource.Length > foldersTarget.Length && index = foldersTarget.Length then
        // Create parts for the new link
        let link = Seq.replicate (foldersSource.Length - foldersTarget.Length) ".."
        // Compose the link
        String.Join('/', link)
      else if foldersTarget.Length > foldersSource.Length && index = foldersSource.Length then
        // Create parts for the new link
        let link =
          seq [
            yield "."
            // For every non-matching part of the target, including the last matching part (because the child .md will be in a subfolder)
            for i in foldersSource.Length - 1 .. foldersTarget.Length - 1 do
              // go down a level
              yield foldersTarget.[i]
          ]
        // Compose the link
        String.Join('/', link)
      else
        // Create parts for the new link
        let link =
          seq [
            // For every non-matching part of the source..
            for _ in 0 .. foldersSource.Length - index - 2 do
              // go up a level
              yield ".."

            // For every non-matching part of the target
            for i in index .. foldersTarget.Length - 1 do
              // go down a level
              yield foldersTarget.[i]
          ]

        // Compose the link
        String.Join('/', link)

  /// <summary>
  /// Creates a link for given <paramref name="target"/>
  /// </summary>
  /// <param name="source">Link from</param>
  /// <param name="target">Link to</param>
  /// <param name="structure">Type structure</param>
  let createLink(source: IType, target: IType, structure: IReadOnlyDictionary<IType, string>, _: GitPlatform) =
    let mutable resultTarget, resultSource = null, null
    if structure.TryGetValue(target, &resultTarget) && structure.TryGetValue(source, &resultSource) then
      processTarget resultSource resultTarget
    else
      ""
