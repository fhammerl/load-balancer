using System;

namespace LoadBalancer
{
    public class RandomLoadBalancer : LoadBalancer
    {
        public RandomLoadBalancer(IProviderRegistry providerRegistry) : base(providerRegistry)
        {
        }

        public override string Get()
        {
            return providerRegistry.Providers[new Random().Next(0, providerRegistry.Providers.Count)].Get();
        }
    }
}
