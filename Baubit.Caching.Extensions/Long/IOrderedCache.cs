using System;

namespace Baubit.Caching.Extensions.Long
{
    public interface IOrderedCache<TValue> : Caching.IOrderedCache<long, TValue>
    {
    }
}
