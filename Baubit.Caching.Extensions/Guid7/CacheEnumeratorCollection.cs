using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Collection of cache enumerators for managing multiple concurrent consumers of cached entries with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="CacheEnumeratorCollection{TId}"/> with Guid as the identifier type.
    /// </summary>
    /// <remarks>
    /// This class is thread-safe and designed to track multiple enumerators reading from the same cache concurrently.
    /// It enables automatic eviction of entries that all enumerators have passed, preventing memory leaks in multi-consumer scenarios.
    /// </remarks>
    public class CacheEnumeratorCollection : CacheEnumeratorCollection<Guid>
    {
    }
}
