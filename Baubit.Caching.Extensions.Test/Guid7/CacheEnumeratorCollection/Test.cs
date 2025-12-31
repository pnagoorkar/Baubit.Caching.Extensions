namespace Baubit.Caching.Extensions.Test.Guid7.CacheEnumeratorCollection
{
    /// <summary>
    /// Unit tests for <see cref="Baubit.Caching.Extensions.Guid7.CacheEnumeratorCollection"/>
    /// Verifies that the specialized Guid-based wrapper properly inherits from the base generic type.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Constructor_CreatesCollection()
        {
            // Arrange & Act
            var collection = new Extensions.Guid7.CacheEnumeratorCollection();

            // Assert
            Assert.NotNull(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_InheritsFromBaseCollection()
        {
            // Arrange & Act
            var collection = new Extensions.Guid7.CacheEnumeratorCollection();

            // Assert
            Assert.IsAssignableFrom<Baubit.Caching.CacheEnumeratorCollection<Guid>>(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_CanBeUsedInFactory()
        {
            // Arrange
            Func<Extensions.Guid7.CacheEnumeratorCollection> factory =
                () => new Extensions.Guid7.CacheEnumeratorCollection();

            // Act
            var collection = factory();

            // Assert
            Assert.NotNull(collection);
            Assert.IsType<Extensions.Guid7.CacheEnumeratorCollection>(collection);
        }

        [Fact]
        public void CacheEnumeratorCollection_SupportsMultipleInstances()
        {
            // Arrange & Act
            var collection1 = new Extensions.Guid7.CacheEnumeratorCollection();
            var collection2 = new Extensions.Guid7.CacheEnumeratorCollection();

            // Assert
            Assert.NotNull(collection1);
            Assert.NotNull(collection2);
            Assert.NotSame(collection1, collection2);
        }

        [Fact]
        public void CacheEnumeratorCollection_SpecializesWithGuidId()
        {
            // Arrange & Act
            var collection = new Extensions.Guid7.CacheEnumeratorCollection();

            // Assert - Verify it's using Guid as TId
            var collectionType = collection.GetType();
            var baseType = collectionType.BaseType;
            Assert.NotNull(baseType);
            Assert.True(baseType.IsGenericType);
            var genericArgs = baseType.GetGenericArguments();
            Assert.Single(genericArgs);
            Assert.Equal(typeof(Guid), genericArgs[0]);
        }
    }
}
