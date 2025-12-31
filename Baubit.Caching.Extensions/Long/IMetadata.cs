using System;

namespace Baubit.Caching.Extensions.Long
{
    /// <summary>
    /// Interface for cache metadata operations with long identifiers.
    /// This type provides backward compatibility by specializing <see cref="IMetadata{TId}"/> with long as the identifier type.
    /// </summary>
    /// <remarks>
    /// Metadata maintains the ordered structure of cache entries, tracking head/tail positions,
    /// deleted node positions, and providing navigation operations for sequential access.
    /// All operations are thread-safe.
    /// </remarks>
    public interface IMetadata : IMetadata<long>
    {
    }
}
