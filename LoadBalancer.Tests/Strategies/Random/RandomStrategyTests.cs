using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using Moq;
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
        public void RandomStrategy_ReturnsProviderAccordingToRandomNumberGenerated()
        {
            // Arrange
            var mockRandom = new Mock<IRandomNumberGenerator>();
            mockRandom.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Returns(0).Returns(2); 
            var strategy = new RandomLoadBalancerStrategy(mockRandom.Object);

            var providers = new List<IProvider>();
            providers.Add(new Provider("0"));
            providers.Add(new Provider("1"));
            providers.Add(new Provider("2"));

            // Act & Assert
            Assert.AreEqual("1", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("0", strategy.SelectProvider(providers).Get());
            Assert.AreEqual("2", strategy.SelectProvider(providers).Get());
        }

    }
}