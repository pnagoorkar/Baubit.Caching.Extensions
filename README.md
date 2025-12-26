# Baubit.Caching.Extensions

[![CircleCI](https://dl.circleci.com/status-badge/img/circleci/TpM4QUH8Djox7cjDaNpup5/2zTgJzKbD2m3nXCf5LKvqS/tree/master.svg?style=svg)](https://dl.circleci.com/status-badge/redirect/circleci/TpM4QUH8Djox7cjDaNpup5/2zTgJzKbD2m3nXCf5LKvqS/tree/master)
[![codecov](https://codecov.io/gh/pnagoorkar/Baubit.Caching.Extensions/branch/master/graph/badge.svg)](https://codecov.io/gh/pnagoorkar/Baubit.Caching.Extensions)<br/>
[![NuGet](https://img.shields.io/nuget/v/Baubit.Caching.Extensions.svg)](https://www.nuget.org/packages/Baubit.Caching.Extensions/)
[![NuGet](https://img.shields.io/nuget/dt/Baubit.Caching.Extensions.svg)](https://www.nuget.org/packages/Baubit.Caching.Extensions) <br/>
![.NET Standard 2.0](https://img.shields.io/badge/.NET%20Standard-2.0-512BD4?logo=dotnet&logoColor=white)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)<br/>
[![Known Vulnerabilities](https://snyk.io/test/github/pnagoorkar/Baubit.Caching.Extensions/badge.svg)](https://snyk.io/test/github/pnagoorkar/Baubit.Caching.Extensions)

Backward-compatible type specializations for [Baubit.Caching](https://github.com/pnagoorkar/Baubit.Caching) with concrete ID types (`long` and `Guid`).

## Why This Package Exists

Baubit.Caching v2025.52+ introduced generic ID types (`TId`) for maximum flexibility. While this makes the core library more powerful, it adds complexity for simple use cases.

**This package bridges the gap** by providing concrete type specializations that:
- Maintain **backward compatibility** for projects using primitive IDs (`long`, `Guid`)
- Reduce **boilerplate** - no generic type parameters on every declaration
- Keep Baubit.Caching's core **surface area minimal** while supporting common scenarios

## Installation

```bash
dotnet add package Baubit.Caching.Extensions
```

## Quick Comparison

### Generic API (Baubit.Caching)
```csharp
// Generic - flexible but verbose
OrderedCache<Guid, MyData> cache = new OrderedCache<Guid, MyData>(...);
IOrderedCache<Guid, MyData> myCache = cache;
```

### Specialized API (Baubit.Caching.Extensions)
```csharp
// Specialized - simpler for common cases
using Baubit.Caching.Extensions.Guid7;

OrderedCache<MyData> cache = new OrderedCache<MyData>(...);
IOrderedCache<MyData> myCache = cache;
```

## What's Included

### 1. Guid7 Namespace - GuidV7-based IDs
**Use when**: You need time-ordered, globally unique identifiers.

```csharp
using Baubit.Caching.Extensions.Guid7;
using Baubit.Caching.Extensions.Guid7.InMemory;
using Baubit.Identity;

var config = new Configuration { MaxL1Capacity = 100 };
var generator = GuidV7Generator.CreateNew();
var l1Store = new Store<string>(generator, loggerFactory);
var l2Store = new Store<string>(generator, loggerFactory);
var metadata = new Metadata(config, loggerFactory);

var cache = new OrderedCache<string>(config, l1Store, l2Store, metadata, loggerFactory);
```

**Types provided:**
- `OrderedCache<TValue>` → `OrderedCache<Guid, TValue>`
- `IOrderedCache<TValue>` → `IOrderedCache<Guid, TValue>`
- `IStore<TValue>` → `IStore<Guid, TValue>`
- `IMetadata` → `IMetadata<Guid>`
- `CacheEnumeratorCollection` → `CacheEnumeratorCollection<Guid>`
- `ICacheAsyncEnumeratorFactory<TValue>` → `ICacheAsyncEnumeratorFactory<Guid, TValue>`
- `ICacheEnumerator` → `ICacheEnumerator<Guid>`
- `InMemory.Store<TValue>` → `InMemory.Store<Guid, TValue>`
- `InMemory.Metadata` → `InMemory.Metadata<Guid>`
- `InMemory.Entry<TValue>` → `InMemory.Entry<Guid, TValue>`

### 2. Long Namespace - Sequential Integer IDs
**Use when**: You need simple, sequential numeric identifiers.

```csharp
using Baubit.Caching.Extensions.Long;
using Baubit.Caching.Extensions.Long.InMemory;

var config = new Configuration { MaxL1Capacity = 100 };
var l1Store = new Store<string>(loggerFactory);
var l2Store = new Store<string>(loggerFactory);
var metadata = new Metadata(config, loggerFactory);

var cache = new OrderedCache<string>(config, l1Store, l2Store, metadata, loggerFactory);
```

**Types provided:**
- `OrderedCache<TValue>` → `OrderedCache<long, TValue>`
- `IOrderedCache<TValue>` → `IOrderedCache<long, TValue>`
- `IStore<TValue>` → `IStore<long, TValue>`
- `IMetadata` → `IMetadata<long>`
- `CacheEnumeratorCollection` → `CacheEnumeratorCollection<long>`
- `ICacheAsyncEnumeratorFactory<TValue>` → `ICacheAsyncEnumeratorFactory<long, TValue>`
- `ICacheEnumerator` → `ICacheEnumerator<long>`
- `InMemory.Store<TValue>` → `InMemory.Store<long, TValue>`
- `InMemory.Metadata` → `InMemory.Metadata<long>`
- `InMemory.Entry<TValue>` → `InMemory.Entry<long, TValue>`

## Key Differences

### ID Generation

#### Guid7 (GuidV7)
- **Auto-generated**: Pass `IIdentityGenerator` (e.g., `GuidV7Generator`) to `Store` constructor
- **Time-ordered**: IDs naturally sort chronologically
- **Globally unique**: Safe for distributed systems

```csharp
var generator = GuidV7Generator.CreateNew();
var store = new Store<string>(generator, loggerFactory);
```

#### Long (Sequential)
- **Auto-generated**: Starts at 1, increments by 1
- **Sequential**: IDs are monotonically increasing integers
- **Compact**: Smaller memory footprint than GUIDs

```csharp
var store = new Store<string>(loggerFactory);  // No generator needed
```

## Migration Guide

### From Generic Baubit.Caching

**Before:**
```csharp
using Baubit.Caching;

OrderedCache<Guid, MyData> cache = new OrderedCache<Guid, MyData>(...);
IOrderedCache<Guid, MyData> iCache = cache;
```

**After:**
```csharp
using Baubit.Caching.Extensions.Guid7;

OrderedCache<MyData> cache = new OrderedCache<MyData>(...);
IOrderedCache<MyData> iCache = cache;
```

### Namespace Mapping

| Generic Type | Guid7 Specialization | Long Specialization |
|--------------|---------------------|-------------------|
| `OrderedCache<Guid, T>` | `Guid7.OrderedCache<T>` | - |
| `OrderedCache<long, T>` | - | `Long.OrderedCache<T>` |
| `IStore<Guid, T>` | `Guid7.IStore<T>` | - |
| `IStore<long, T>` | - | `Long.IStore<T>` |
| `IMetadata<Guid>` | `Guid7.IMetadata` | - |
| `IMetadata<long>` | - | `Long.IMetadata` |

## When NOT to Use This Package

- **Custom ID types**: If you need `int`, `string`, or custom structs as IDs → use **Baubit.Caching** directly
- **Maximum flexibility**: If you want full control over generic type parameters → use **Baubit.Caching** directly
- **Mixed ID types**: If you need multiple cache types with different IDs in same project → use **Baubit.Caching** directly

## For the Full Story

This package is a thin compatibility layer. For complete documentation, see:

**[Baubit.Caching Documentation](https://github.com/pnagoorkar/Baubit.Caching)**

Topics covered there:
- Architecture and design rationale
- Complete API reference with examples
- Performance characteristics and benchmarks
- Thread safety guarantees
- Multi-consumer streaming patterns
- Async enumeration
- Eviction strategies
- Configuration options

## License

MIT License - see [LICENSE](LICENSE) file for details.

## Contributing

Contributions welcome! Please:
1. Read [Baubit.Caching's architecture](https://github.com/pnagoorkar/Baubit.Caching#architecture) first
2. Keep changes minimal - this is a compatibility layer
3. Maintain 100% test coverage
4. Follow existing code style

## Version Compatibility

This package tracks Baubit.Caching versions:
- `Baubit.Caching.Extensions 2025.52.x` → `Baubit.Caching 2025.52.x`
- Always use matching versions to avoid breaking changes

