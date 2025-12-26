using Microsoft.Extensions.Logging;
using System;

namespace Baubit.Caching.Extensions.Long.InMemory
{
    /// <summary>
    /// In-memory implementation of <see cref="IStore{TValue}"/> using a dictionary for storage with long identifiers.
    /// This type provides backward compatibility by specializing <see cref="Caching.InMemory.Store{TId, TValue}"/> with long as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in this store.</typeparam>
    /// <remarks>
    /// <para>
    /// This store implementation provides thread-safe operations for concurrent readers/writers and supports
    /// automatic ID generation using monotonically increasing long identifiers starting from 1.
    /// </para>
    /// <para>
    /// The store can be configured with minimum and maximum capacity bounds for adaptive resizing behavior.
    /// When uncapped, the store grows dynamically based on demand.
    /// </para>
    /// </remarks>
    public class Store<TValue> : Caching.InMemory.Store<long, TValue>, IStore<TValue>
    {
        /// <summary>
        /// Logger instance for diagnostic information.
        /// </summary>
        private ILogger<Store<TValue>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Store{TValue}"/> class with capacity bounds.
        /// </summary>
        /// <param name="minCap">Minimum capacity for the store. When set, the store will maintain at least this capacity.</param>
        /// <param name="maxCap">Maximum capacity for the store. When set, the store will not exceed this capacity.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public Store(long? minCap,
                     long? maxCap,
                     ILoggerFactory loggerFactory) : base(minCap, maxCap, GenerateNextId, loggerFactory)
        {
            logger = loggerFactory.CreateLogger<Store<TValue>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store{TValue}"/> class without capacity bounds (uncapped).
        /// </summary>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public Store(ILoggerFactory loggerFactory) : this(null, null, loggerFactory)
        {

        }

        /// <summary>
        /// Generates the next long identifier for a new cache entry.
        /// </summary>
        /// <param name="lastGeneratedId">The last generated ID. Can be null for the first ID.</param>
        /// <returns>
        /// The next long to use as an entry identifier. Returns 1 for the first ID, then increments by 1 for each subsequent ID.
        /// </returns>
        /// <remarks>
        /// This method produces monotonically increasing identifiers starting from 1.
        /// Each call increments the previous ID by 1 to maintain sequential ordering.
        /// </remarks>
        private static long? GenerateNextId(long? lastGeneratedId)
        {
            return lastGeneratedId.HasValue ? lastGeneratedId.Value + 1 : 1;
        }
    }
}
