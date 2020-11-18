using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LoadBalancer.Tests
{
    public class RoundRobinStrategyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoundRobinStrategy_ReturnsProvidersInOrder()
        {
            // Arrange
            var strategy = new RoundRobinStrategy();

            var providers = new List<IProvider>();
            providers.Add(new Provider("0"));
            providers.Add(new Provider("1"));
            providers.Add(new Provider("2"));

            // Act & Assert
            Assert.AreEqual("0", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("1", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("2", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("0", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("1", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("2", strategy.SelectProvider(providers).Get());
        }

    }
}