using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Interface for an ordered cache with Guid identifiers and generic value types.
    /// This type provides backward compatibility by specializing <see cref="Caching.IOrderedCache{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// OrderedCache provides time-ordered storage with O(1) lookups, two-tier (L1/L2) storage,
    /// deletion-resilient iteration, and async enumeration for streaming scenarios.
    /// Guid identifiers are typically GuidV7, which are naturally time-ordered.
    /// All operations are thread-safe.
    /// </remarks>
    public interface IOrderedCache<TValue> : Caching.IOrderedCache<Guid, TValue>
    {
    }
}
