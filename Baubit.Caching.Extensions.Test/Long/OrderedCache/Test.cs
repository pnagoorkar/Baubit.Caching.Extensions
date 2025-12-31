using Baubit.Caching;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Baubit.Caching.Extensions.Test.Long.OrderedCache
{
    public class Test
    {
        private readonly ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

        [Fact]
        public void Constructor_WithAllParameters_CreatesCache()
        {
            var config = new Configuration();
            var l1Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var l2Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var metadata = new Extensions.Long.InMemory.Metadata(config, loggerFactory);
            Func<Extensions.Long.CacheEnumeratorCollection> enumeratorCollectionFactory =
                () => new Extensions.Long.CacheEnumeratorCollection();
            var cache = new Extensions.Long.OrderedCache<string>(
                config, l1Store, l2Store, metadata, loggerFactory,
                enumeratorCollectionFactory, null);
            Assert.NotNull(cache);
        }

        [Fact]
        public void Constructor_WithMinimalParameters_CreatesCache()
        {
            var config = new Configuration();
            var l1Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var l2Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var metadata = new Extensions.Long.InMemory.Metadata(config, loggerFactory);
            var cache = new Extensions.Long.OrderedCache<string>(
                config, l1Store, l2Store, metadata, loggerFactory);
            Assert.NotNull(cache);
        }

        [Fact]
        public void OrderedCache_InheritsFromBaseOrderedCache()
        {
            var config = new Configuration();
            var l1Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var l2Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var metadata = new Extensions.Long.InMemory.Metadata(config, loggerFactory);
            var cache = new Extensions.Long.OrderedCache<string>(
                config, l1Store, l2Store, metadata, loggerFactory);
            Assert.IsAssignableFrom<Baubit.Caching.OrderedCache<long, string>>(cache);
        }

        [Fact]
        public void OrderedCache_ImplementsIOrderedCache()
        {
            var config = new Configuration();
            var l1Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var l2Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var metadata = new Extensions.Long.InMemory.Metadata(config, loggerFactory);
            var cache = new Extensions.Long.OrderedCache<string>(
                config, l1Store, l2Store, metadata, loggerFactory);
            Assert.IsAssignableFrom<Extensions.Long.IOrderedCache<string>>(cache);
            Assert.IsAssignableFrom<Baubit.Caching.IOrderedCache<long, string>>(cache);
        }

        [Fact]
        public void OrderedCache_SpecializesWithLongId()
        {
            var config = new Configuration();
            var l1Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var l2Store = new Extensions.Long.InMemory.Store<string>(loggerFactory);
            var metadata = new Extensions.Long.InMemory.Metadata(config, loggerFactory);
            var cache = new Extensions.Long.OrderedCache<string>(
                config, l1Store, l2Store, metadata, loggerFactory);
            var cacheType = cache.GetType();
            var baseType = cacheType.BaseType;
            Assert.NotNull(baseType);
            Assert.True(baseType.IsGenericType);
            var genericArgs = baseType.GetGenericArguments();
            Assert.Equal(2, genericArgs.Length);
            Assert.Equal(typeof(long), genericArgs[0]);
            Assert.Equal(typeof(string), genericArgs[1]);
        }
    }
}
