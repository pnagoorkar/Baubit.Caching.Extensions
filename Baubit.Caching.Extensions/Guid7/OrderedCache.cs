using Microsoft.Extensions.Logging;
using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Thread-safe ordered cache with Guid identifiers and generic value types.
    /// This type provides backward compatibility by specializing <see cref="OrderedCache{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// <para>
    /// OrderedCache provides time-ordered storage using GuidV7 identifiers (naturally chronological),
    /// O(1) lookups by ID, two-tier storage (L1/L2) with automatic fallback and replenishment,
    /// deletion-resilient iteration, and async enumeration for zero-latency producer-consumer streaming.
    /// </para>
    /// <para>
    /// All operations are thread-safe. The cache tracks multiple concurrent enumerators and automatically
    /// evicts entries that all consumers have passed, preventing memory leaks in multi-consumer scenarios.
    /// </para>
    /// <para>
    /// Use this cache for event sourcing, CDC pipelines, audit logs, FIFO-ish queues with random access,
    /// and time-series buffering. Do not use for generic key/value caching or TTL-based caching.
    /// </para>
    /// </remarks>
    public class OrderedCache<TValue> : OrderedCache<Guid, TValue>, IOrderedCache<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedCache{TValue}"/> class.
        /// </summary>
        /// <param name="cacheConfiguration">Cache configuration including capacity and eviction settings.</param>
        /// <param name="l1Store">L1 (primary) storage for frequently accessed entries.</param>
        /// <param name="l2Store">L2 (secondary) storage for less frequently accessed entries. Can be null for single-tier operation.</param>
        /// <param name="metadata">Metadata store for tracking entry ordering and navigation.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        /// <param name="cacheEnumeratorCollectionFactory">Optional factory for creating enumerator collections to track multiple consumers. If null, a default factory is used.</param>
        /// <param name="enumeratorFactory">Optional factory for creating async enumerators. If null, streaming enumeration is not available.</param>
        public OrderedCache(Configuration cacheConfiguration,
                            IStore<TValue> l1Store,
                            IStore<TValue> l2Store,
                            IMetadata metadata,
                            ILoggerFactory loggerFactory,
                            Func<CacheEnumeratorCollection> cacheEnumeratorCollectionFactory = null,
                            ICacheAsyncEnumeratorFactory<TValue> enumeratorFactory = null) : base(cacheConfiguration,
                                                                                                  l1Store,
                                                                                                  l2Store,
                                                                                                  metadata,
                                                                                                  loggerFactory,
                                                                                                  cacheEnumeratorCollectionFactory,
                                                                                                  enumeratorFactory)
        {
        }
    }
}
