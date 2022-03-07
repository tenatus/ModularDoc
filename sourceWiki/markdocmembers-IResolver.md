# IResolver `interface`

## Description
Type resolver

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Members
  MarkDoc.Members.IResolver[[IResolver]]
  class MarkDoc.Members.IResolver interfaceStyle;
  end
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `Lazy`&lt;`IReadOnlyDictionary`&gt; | [`Types`](markdocmembers-IResolver#types)<br>Resolved types | `get` |

### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Resolve`](markdocmembers-IResolver#resolve)(`string` assembly)<br>Resolves `assembly` types |
| `Task` | [`ResolveAsync`](markdocmembers-IResolver#resolveasync)([`IMemberSettings`](./markdocmembers-IMemberSettings) memberSettings, [`IGlobalSettings`](./markdoccore-IGlobalSettings) globalSettings)<br>Resolves all assemblies based on the given settings |
| `bool` | [`TryFindType`](markdocmembers-IResolver#tryfindtype)(`string` fullname, out [`IType`](./markdocmemberstypes-IType) result) |
| `bool` | [`TryGetMemberSourceLine`](markdocmembers-IResolver#trygetmembersourceline)(`int` token, out `int` line, out `string` source) |

## Details
### Summary
Type resolver

### Methods
#### ResolveAsync
```csharp
public abstract Task ResolveAsync(IMemberSettings memberSettings, IGlobalSettings globalSettings)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`IMemberSettings`](./markdocmembers-IMemberSettings) | memberSettings |   |
| [`IGlobalSettings`](./markdoccore-IGlobalSettings) | globalSettings |   |

##### Summary
Resolves all assemblies based on the given settings

##### Returns


#### Resolve
```csharp
public abstract void Resolve(string assembly)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | assembly | Path to assembly |

##### Summary
Resolves `assembly` types

#### TryFindType
```csharp
public abstract bool TryFindType(string fullname, out IType result)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | fullname |   |
| `out` [`IType`](./markdocmemberstypes-IType) | result |   |

#### TryGetMemberSourceLine
```csharp
public abstract bool TryGetMemberSourceLine(int token, out int line, out string source)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `int` | token |   |
| `out` `int` | line |   |
| `out` `string` | source |   |

### Properties
#### Types
```csharp
public abstract Lazy Types { get }
```
##### Summary
Resolved types

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)