using System;

namespace Baubit.Caching.Extensions.Long.InMemory
{
    /// <summary>
    /// Represents a cache entry with a long identifier and a value of type <typeparamref name="TValue"/>.
    /// This type provides backward compatibility by specializing <see cref="Caching.InMemory.Entry{TId, TValue}"/> with long as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of value stored in this entry.</typeparam>
    /// <remarks>
    /// Entries are immutable once created and represent a single cached value with its associated identifier and timestamp.
    /// Long identifiers provide natural sequential ordering for scenarios where monotonically increasing IDs are preferred.
    /// </remarks>
    public class Entry<TValue> : Caching.InMemory.Entry<long, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entry{TValue}"/> class.
        /// </summary>
        /// <param name="id">The long identifier for this entry.</param>
        /// <param name="value">The value to store in this entry.</param>
        public Entry(long id, TValue value) : base(id, value)
        {
        }
    }
}
