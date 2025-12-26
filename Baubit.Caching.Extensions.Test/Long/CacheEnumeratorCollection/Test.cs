namespace Baubit.Caching.Extensions.Test.Long.CacheEnumeratorCollection
{
    /// <summary>
    /// Unit tests for <see cref="Baubit.Caching.Extensions.Long.CacheEnumeratorCollection"/>
    /// Verifies that the specialized Long-based wrapper properly inherits from the base generic type.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Constructor_CreatesCollection()
        {
            // Arrange & Act
            var collection = new Extensions.Long.CacheEnumeratorCollection();

            // Assert
            Assert.NotNull(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_InheritsFromBaseCollection()
        {
            // Arrange & Act
            var collection = new Extensions.Long.CacheEnumeratorCollection();

            // Assert
            Assert.IsAssignableFrom<Baubit.Caching.CacheEnumeratorCollection<long>>(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_CanBeUsedInFactory()
        {
            // Arrange
            Func<Extensions.Long.CacheEnumeratorCollection> factory =
                () => new Extensions.Long.CacheEnumeratorCollection();

            // Act
            var collection = factory();

            // Assert
            Assert.NotNull(collection);
            Assert.IsType<Extensions.Long.CacheEnumeratorCollection>(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_SupportsMultipleInstances()
        {
            // Arrange & Act
            var collection1 = new Extensions.Long.CacheEnumeratorCollection();
            var collection2 = new Extensions.Long.CacheEnumeratorCollection();

            // Assert
            Assert.NotNull(collection1);
            Assert.NotNull(collection2);
            Assert.NotSame(collection1, collection2);
        }

        [Fact]
        public void CacheEnumeratorCollection_SpecializesWithLongId()
        {
            // Arrange & Act
            var collection = new Extensions.Long.CacheEnumeratorCollection();

            // Assert - Verify it's using long as TId
            var collectionType = collection.GetType();
            var baseType = collectionType.BaseType;
            Assert.NotNull(baseType);
            Assert.True(baseType.IsGenericType);
            var genericArgs = baseType.GetGenericArguments();
            Assert.Single(genericArgs);
            Assert.Equal(typeof(long), genericArgs[0]);
        }
    }
}
