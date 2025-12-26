using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Interface for cache metadata operations with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="IMetadata{TId}"/> with Guid as the identifier type.
    /// </summary>
    /// <remarks>
    /// Metadata maintains the ordered structure of cache entries, tracking head/tail positions,
    /// deleted node positions, and providing navigation operations for sequential access.
    /// All operations are thread-safe.
    /// </remarks>
    public interface IMetadata : IMetadata<Guid>
    {
    }
}
