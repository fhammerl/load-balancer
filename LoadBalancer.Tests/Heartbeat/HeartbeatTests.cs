using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace LoadBalancer.Tests
{
    public class HeartbeatTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void Heartbeat_CheckReturnsFalse_ExcludesProvider()
        {
            // Arrange
            // Mock the IScheduler and a provider and Spy that the ProviderRegistry's right method is called
        }
        [Test]
        [Ignore("TODO")]
        public void Heartbeat_CheckReturnsTrueOnExcludedTwice_IncludesProvider()
        {
            // Arrange
            // Mock the IScheduler and a provider and Spy that the ProviderRegistry's method is called
        }

    }
}