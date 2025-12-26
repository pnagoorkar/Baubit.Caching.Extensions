using Microsoft.Extensions.Logging;
using System;

namespace Baubit.Caching.Extensions.Long.InMemory
{
    public class Metadata : Caching.InMemory.Metadata<long>, IMetadata
    {
        public Metadata(Configuration configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }
    }
}
