using System;

namespace Baubit.Caching.Extensions.Guid7.InMemory
{
    /// <summary>
    /// Represents a cache entry with a Guid identifier and a value of type <typeparamref name="TValue"/>.
    /// This type provides backward compatibility by specializing <see cref="Caching.InMemory.Entry{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of value stored in this entry.</typeparam>
    /// <remarks>
    /// Entries are immutable once created and represent a single cached value with its associated identifier and timestamp.
    /// Guid identifiers are typically GuidV7, which are naturally time-ordered.
    /// </remarks>
    public class Entry<TValue> : Caching.InMemory.Entry<Guid, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entry{TValue}"/> class.
        /// </summary>
        /// <param name="id">The Guid identifier for this entry.</param>
        /// <param name="value">The value to store in this entry.</param>
        public Entry(Guid id, TValue value) : base(id, value)
        {
        }
    }
}
