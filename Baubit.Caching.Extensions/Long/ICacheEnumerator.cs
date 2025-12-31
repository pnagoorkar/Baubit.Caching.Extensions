using System;

namespace Baubit.Caching.Extensions.Long
{
    /// <summary>
    /// Interface for enumerating cache entries with long identifiers.
    /// This type provides backward compatibility by specializing <see cref="ICacheEnumerator{TId}"/> with long as the identifier type.
    /// </summary>
    /// <remarks>
    /// Cache enumerators track position within the ordered cache and enable sequential iteration
    /// through entries while supporting deletion-resilient enumeration.
    /// </remarks>
    public interface ICacheEnumerator : ICacheEnumerator<long>
    {
    }
}
