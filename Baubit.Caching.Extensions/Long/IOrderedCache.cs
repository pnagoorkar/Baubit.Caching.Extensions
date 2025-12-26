using System;

namespace Baubit.Caching.Extensions.Long
{
    /// <summary>
    /// Interface for an ordered cache with long identifiers and generic value types.
    /// This type provides backward compatibility by specializing <see cref="Caching.IOrderedCache{TId, TValue}"/> with long as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// OrderedCache provides time-ordered storage with O(1) lookups, two-tier (L1/L2) storage,
    /// deletion-resilient iteration, and async enumeration for streaming scenarios.
    /// Long identifiers provide natural sequential ordering for scenarios where monotonically increasing IDs are preferred.
    /// All operations are thread-safe.
    /// </remarks>
    public interface IOrderedCache<TValue> : Caching.IOrderedCache<long, TValue>
    {
    }
}
