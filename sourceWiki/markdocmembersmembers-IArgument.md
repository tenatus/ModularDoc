# IArgument `interface`

## Description
Interface for [IMethod](./markdocmembersmembers-IMethod) arguments

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Members.Members
  MarkDoc.Members.Members.IArgument[[IArgument]]
  class MarkDoc.Members.Members.IArgument interfaceStyle;
  end
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| [`ArgumentType`](./markdocmembersenums-ArgumentType) | [`Keyword`](markdocmembersmembers-IArgument#keyword)<br>Argument keyword | `get` |
| `string` | [`Name`](markdocmembersmembers-IArgument#name)<br>Argument name | `get` |
| [`IResType`](./markdocmembersresolvedtypes-IResType) | [`Type`](markdocmembersmembers-IArgument#type)<br>Argument type | `get` |

## Details
### Summary
Interface for [IMethod](./markdocmembersmembers-IMethod) arguments

### Properties
#### Name
```csharp
public abstract string Name { get }
```
##### Summary
Argument name

#### Keyword
```csharp
public abstract ArgumentType Keyword { get }
```
##### Summary
Argument keyword

#### Type
```csharp
public abstract IResType Type { get }
```
##### Summary
Argument type

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)