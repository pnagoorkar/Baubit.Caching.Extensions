using Microsoft.Extensions.Logging;
using System;

namespace Baubit.Caching.Extensions.Guid7.InMemory
{
    /// <summary>
    /// In-memory implementation of cache metadata for tracking entry ordering and navigation with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="Caching.InMemory.Metadata{TId}"/> with Guid as the identifier type.
    /// </summary>
    /// <remarks>
    /// Metadata maintains the ordered linked-list structure of cache entries, tracking head/tail positions,
    /// and positions of deleted nodes to enable deletion-resilient iteration. All operations are thread-safe.
    /// </remarks>
    public class Metadata : Caching.InMemory.Metadata<Guid>, IMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Metadata"/> class.
        /// </summary>
        /// <param name="configuration">Cache configuration settings.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public Metadata(Configuration configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }
    }
}
