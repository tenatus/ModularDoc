# IInterface `interface`

## Description
Interface for interface types

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MarkDoc.Members.Types
  MarkDoc.Members.Types.IInterface[[IInterface]]
  class MarkDoc.Members.Types.IInterface interfaceStyle;
  MarkDoc.Members.Types.IType[[IType]]
  class MarkDoc.Members.Types.IType interfaceStyle;
  end
MarkDoc.Members.Types.IType --> MarkDoc.Members.Types.IInterface
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `IReadOnlyCollection`&lt;[`IDelegate`](./markdocmembersmembers-IDelegate)&gt; | [`Delegates`](markdocmemberstypes-IInterface#delegates)<br>Collection of delegates | `get` |
| `IReadOnlyCollection`&lt;[`IEvent`](./markdocmembersmembers-IEvent)&gt; | [`Events`](markdocmemberstypes-IInterface#events)<br>Collection of events | `get` |
| `IReadOnlyDictionary`&lt;`string`, `(Variance Item1, IReadOnlyCollection Item2)`&gt; | [`Generics`](markdocmemberstypes-IInterface#generics)<br>Generics name, and their variance and constraints | `get` |
| `IReadOnlyCollection`&lt;[`IResType`](./markdocmembersresolvedtypes-IResType)&gt; | [`InheritedInterfaces`](markdocmemberstypes-IInterface#inheritedinterfaces)<br>Collection of inherited interfaces | `get` |
| `Lazy`&lt;`IReadOnlyDictionary`&gt; | [`InheritedTypes`](markdocmemberstypes-IInterface#inheritedtypes)<br>Members inherited from derived types | `get` |
| `IReadOnlyCollection`&lt;[`IMethod`](./markdocmembersmembers-IMethod)&gt; | [`Methods`](markdocmemberstypes-IInterface#methods)<br>Collection of methods | `get` |
| `IReadOnlyCollection`&lt;[`IType`](./markdocmemberstypes-IType)&gt; | [`NestedTypes`](markdocmemberstypes-IInterface#nestedtypes)<br>Collection of nested types | `get` |
| `IReadOnlyCollection`&lt;[`IProperty`](./markdocmembersmembers-IProperty)&gt; | [`Properties`](markdocmemberstypes-IInterface#properties)<br>Collection of properties | `get` |

## Details
### Summary
Interface for interface types

### Inheritance
 - [
`IType`
](./markdocmemberstypes-IType)

### Properties
#### InheritedInterfaces
```csharp
public abstract IReadOnlyCollection InheritedInterfaces { get }
```
##### Summary
Collection of inherited interfaces

#### Generics
```csharp
public abstract IReadOnlyDictionary Generics { get }
```
##### Summary
Generics name, and their variance and constraints

#### Delegates
```csharp
public abstract IReadOnlyCollection Delegates { get }
```
##### Summary
Collection of delegates

#### NestedTypes
```csharp
public abstract IReadOnlyCollection NestedTypes { get }
```
##### Summary
Collection of nested types

#### Events
```csharp
public abstract IReadOnlyCollection Events { get }
```
##### Summary
Collection of events

#### Methods
```csharp
public abstract IReadOnlyCollection Methods { get }
```
##### Summary
Collection of methods

#### Properties
```csharp
public abstract IReadOnlyCollection Properties { get }
```
##### Summary
Collection of properties

#### InheritedTypes
```csharp
public abstract Lazy InheritedTypes { get }
```
##### Summary
Members inherited from derived types

*Generated with* [*MarkDoc*](https://github.com/hailstorm75/MarkDoc.Core)