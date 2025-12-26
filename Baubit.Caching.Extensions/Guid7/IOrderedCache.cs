using System;

namespace Baubit.Caching.Extensions.Guid7
{
    public interface IOrderedCache<TValue> : Caching.IOrderedCache<Guid, TValue>
    {
    }
}
