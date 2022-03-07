# IConstructor `interface`

## Description
Interface for type constructors

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Members.Members
  MarkDoc.Members.Members.IConstructor[[IConstructor]]
  class MarkDoc.Members.Members.IConstructor interfaceStyle;
  MarkDoc.Members.Members.IMember[[IMember]]
  class MarkDoc.Members.Members.IMember interfaceStyle;
  end
MarkDoc.Members.Members.IMember --> MarkDoc.Members.Members.IConstructor
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `IReadOnlyCollection`&lt;[`IArgument`](./markdocmembersmembers-IArgument)&gt; | [`Arguments`](markdocmembersmembers-IConstructor#arguments)<br>Method arguments | `get` |

## Details
### Summary
Interface for type constructors

### Inheritance
 - [
`IMember`
](./markdocmembersmembers-IMember)

### Properties
#### Arguments
```csharp
public abstract IReadOnlyCollection Arguments { get }
```
##### Summary
Method arguments

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)