using System;

namespace Baubit.Caching.Extensions.Guid7
{
    public interface IStore<TValue> : IStore<Guid, TValue>
    {
    }
}
