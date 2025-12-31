using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Interface for cache storage operations with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="IStore{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// Store implementations provide the underlying storage mechanism for cache entries.
    /// This abstraction enables pluggable storage backends (in-memory, Redis, etc.)
    /// while maintaining consistent API semantics. All operations are thread-safe.
    /// </remarks>
    public interface IStore<TValue> : IStore<Guid, TValue>
    {
    }
}
