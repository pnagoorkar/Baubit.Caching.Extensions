namespace Baubit.Caching.Extensions.Long
{
    /// <summary>
    /// Factory interface for creating asynchronous cache enumerators with long identifiers.
    /// This type provides backward compatibility by specializing <see cref="ICacheAsyncEnumeratorFactory{TId, TValue}"/> with long as the identifier type.
    /// </summary>
    /// <typeparam name="TValue">The type of values stored in cache entries.</typeparam>
    /// <remarks>
    /// Implementations create enumerators that support async iteration over cache entries,
    /// enabling zero-latency streaming where consumers await future entries without polling.
    /// </remarks>
    public interface ICacheAsyncEnumeratorFactory<TValue> : ICacheAsyncEnumeratorFactory<long, TValue>
    {
    }
}
