using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Interface for enumerating cache entries with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="ICacheEnumerator{TId}"/> with Guid as the identifier type.
    /// </summary>
    /// <remarks>
    /// Cache enumerators track position within the ordered cache and enable sequential iteration
    /// through entries while supporting deletion-resilient enumeration.
    /// </remarks>
    public interface ICacheEnumerator : ICacheEnumerator<Guid>
    {
    }
}
