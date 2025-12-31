using System;

namespace Baubit.Caching.Extensions.Guid7
{
    /// <summary>
    /// Factory interface for creating asynchronous cache enumerators with Guid identifiers.
    /// This type provides backward compatibility by specializing <see cref="ICacheAsyncEnumeratorFactory{TId, TValue}"/> with Guid as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// Implementations create enumerators that support async iteration over cache entries,
    /// enabling zero-latency streaming where consumers await future entries without polling.
    /// </remarks>
    public interface ICacheAsyncEnumeratorFactory<TValue> : ICacheAsyncEnumeratorFactory<Guid, TValue>
    {
    }
}
