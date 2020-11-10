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
        public void LoadBalancer_AddMaxNumberOfProviders_ThrowsNoExceptions()
        {
            // Arrange
            var registry = new ProviderRegistry();
            var providers = new List<Provider>();
            providers.Add(new Provider("0"));

            // Act
            registry.Register(providers);

            // Assert
            Assert.AreEqual(providers, registry.Providers);
        }

        [Test]
        public void LoadBalancer_AddZeroProviders_ThrowsArgumentException()
        {
            // Arrange
            var lb = new ProviderRegistry();
            var providers = new List<Provider>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => lb.Register(providers));

            Assert.AreEqual("Can't have 0 providers", ex.Message);
        }

        [Test]
        public void LoadBalancer_AddElevenProviders_ThrowsArgumentException()
        {
            // Arrange
            var lb = new ProviderRegistry();
            var providers = Enumerable.Repeat<Provider>(null, 11).ToList();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => lb.Register(providers));

            Assert.AreEqual("Can't have more than 10 providers", ex.Message);
        }
    }
}