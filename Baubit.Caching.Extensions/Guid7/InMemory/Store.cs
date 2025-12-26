using Baubit.Identity;
using Microsoft.Extensions.Logging;
using System;

namespace Baubit.Caching.Extensions.Guid7.InMemory
{
    /// <summary>
    /// In-memory implementation of <see cref="IStore{TValue}"/> using a dictionary for storage with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="Caching.InMemory.Store{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in this store.</typeparam>
    /// <remarks>
    /// <para>
    /// This store implementation provides thread-safe operations for concurrent readers/writers and supports
    /// automatic ID generation using GuidV7 (time-ordered) identifiers via the provided <see cref="IIdentityGenerator"/>.
    /// </para>
    /// <para>
    /// The store can be configured with minimum and maximum capacity bounds for adaptive resizing behavior.
    /// When uncapped, the store grows dynamically based on demand.
    /// </para>
    /// </remarks>
    public class Store<TValue> : Caching.InMemory.Store<Guid, TValue>, IStore<TValue>
    {
        /// <summary>
        /// The identity generator used for auto-generating GuidV7 entry IDs.
        /// </summary>
        private readonly IIdentityGenerator identityGenerator;

        /// <summary>
        /// Logger instance for diagnostic information.
        /// </summary>
        private ILogger<Store<TValue>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Store{TValue}"/> class with capacity bounds.
        /// </summary>
        /// <param name="minCap">Minimum capacity for the store. When set, the store will maintain at least this capacity.</param>
        /// <param name="maxCap">Maximum capacity for the store. When set, the store will not exceed this capacity.</param>
        /// <param name="identityGenerator">Identity generator for auto-generating entry IDs. If null, IDs must be provided explicitly.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public Store(long? minCap,
                     long? maxCap,
                     IIdentityGenerator identityGenerator,
                     ILoggerFactory loggerFactory) : base(minCap, maxCap, loggerFactory)
        {
            this.identityGenerator = identityGenerator;
            logger = loggerFactory.CreateLogger<Store<TValue>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store{TValue}"/> class without capacity bounds (uncapped).
        /// </summary>
        /// <param name="identityGenerator">Identity generator for auto-generating entry IDs. If null, IDs must be provided explicitly.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public Store(IIdentityGenerator identityGenerator, ILoggerFactory loggerFactory) : this(null, null, identityGenerator, loggerFactory)
        {

        }

        /// <summary>
        /// Generates the next Guid identifier for a new cache entry.
        /// </summary>
        /// <param name="lastGeneratedId">The last generated ID, used to ensure monotonicity. Can be null for the first ID.</param>
        /// <returns>
        /// The next Guid to use as an entry identifier, or null if no identity generator is configured.
        /// </returns>
        /// <remarks>
        /// This method uses the configured <see cref="IIdentityGenerator"/> to produce time-ordered GuidV7 identifiers.
        /// If a lastGeneratedId is provided, the generator is initialized from it to maintain monotonic ordering.
        /// </remarks>
        protected override Guid? GenerateNextId(Guid? lastGeneratedId)
        {
            if (identityGenerator == null) return null;
            // Initialize from last generated ID if available to ensure monotonicity
            if (lastGeneratedId.HasValue)
            {
                identityGenerator.InitializeFrom(lastGeneratedId.Value);
            }

            return identityGenerator.GetNext();
        }
    }
}
