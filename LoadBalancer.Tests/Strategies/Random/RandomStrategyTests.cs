using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LoadBalancer.Tests
{
    public class RandomStrategyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RandomStrategy_ThrowsNoExceptions()
        {
            // Arrange
            var strategy = new RandomLoadBalancerStrategy();

            // Act
            registry.Register(providers);

            // Assert
            Assert.AreEqual(providers, registry.Providers);
        }

    }
}