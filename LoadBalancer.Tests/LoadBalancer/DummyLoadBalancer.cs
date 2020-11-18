using LoadBalancer.Core;
using LoadBalancer.Providers;

namespace LoadBalancer.Tests
{
    class DummyLoadBalancer : AbstractLoadBalancer
    {
        public DummyLoadBalancer(IProviderRegistry providerRegistry) : base(providerRegistry)
        {
        }

        public override string Get()
        {
            throw new System.NotImplementedException();
        }
    }
}