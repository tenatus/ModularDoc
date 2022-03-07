# IDiagramResolver `interface`

## Description
Interface for diagram resolvers

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Diagrams
  MarkDoc.Diagrams.IDiagramResolver[[IDiagramResolver]]
  class MarkDoc.Diagrams.IDiagramResolver interfaceStyle;
  end
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `bool` | [`TryGenerateDiagram`](markdocdiagrams-IDiagramResolver#trygeneratediagram)([`IType`](./markdocmemberstypes-IType) type, out `(string name, string content)` diagram) |

## Details
### Summary
Interface for diagram resolvers

### Methods
#### TryGenerateDiagram
```csharp
public abstract bool TryGenerateDiagram(IType type, out (string name, string content) diagram)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`IType`](./markdocmemberstypes-IType) | type |   |
| `out` `(string name, string content)` | diagram |   |

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)