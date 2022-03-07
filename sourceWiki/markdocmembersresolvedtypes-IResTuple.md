# IResTuple `interface`

## Description
Interface for resolved tuples

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Members.ResolvedTypes
  MarkDoc.Members.ResolvedTypes.IResTuple[[IResTuple]]
  class MarkDoc.Members.ResolvedTypes.IResTuple interfaceStyle;
  MarkDoc.Members.ResolvedTypes.IResType[[IResType]]
  class MarkDoc.Members.ResolvedTypes.IResType interfaceStyle;
  end
MarkDoc.Members.ResolvedTypes.IResType --> MarkDoc.Members.ResolvedTypes.IResTuple
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `IReadOnlyCollection`&lt;`(string Item1, IResType Item2)`&gt; | [`Fields`](markdocmembersresolvedtypes-IResTuple#fields)<br>Tuple fields | `get` |
| `bool` | [`IsValueTuple`](markdocmembersresolvedtypes-IResTuple#isvaluetuple)<br>Determines whether the tuple is a value tuple | `get` |

## Details
### Summary
Interface for resolved tuples

### Inheritance
 - [
`IResType`
](./markdocmembersresolvedtypes-IResType)

### Properties
#### Fields
```csharp
public abstract IReadOnlyCollection Fields { get }
```
##### Summary
Tuple fields

#### IsValueTuple
```csharp
public abstract bool IsValueTuple { get }
```
##### Summary
Determines whether the tuple is a value tuple

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)