using LoadBalancer.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadBalancer.Tests
{
    public class ProviderRegistryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProviderRegistry_AddMaxNumberOfProviders_ThrowsNoExceptions()
        {
            // Arrange
            var registry = new ProviderRegistry();
            var providers = new List<IProvider>();
            providers.Add(new Provider("0"));

            // Act
            registry.Register(providers);

            // Assert
            Assert.AreEqual(providers, registry.Providers);
        }

        [Test]
        public void ProviderRegistry_AddZeroProviders_ThrowsArgumentException()
        {
            // Arrange
            var lb = new ProviderRegistry();
            var providers = new List<IProvider>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => lb.Register(providers));

            Assert.AreEqual("Can't have 0 providers", ex.Message);
        }

        [Test]
        public void ProviderRegistry_AddElevenProviders_ThrowsArgumentException() // TODO: Change to ProviderRegistry_AddMoreThanMaxProviders_ThrowsArgumentException when the hardcoded constant becomes configurable
        {
            // Arrange
            var lb = new ProviderRegistry();
            var providers = Enumerable.Repeat<IProvider>(null, 11).ToList();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => lb.Register(providers));

            Assert.AreEqual("Can't have more than 10 providers", ex.Message);
        }
    }
}