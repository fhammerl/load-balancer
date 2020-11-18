using LoadBalancer.Providers;
using System;
using System.Collections.Generic;

namespace LoadBalancer.LoadBalancer.Strategies
{
    public class RandomStrategy : ILoadBalancerStrategy
    {
        private readonly IRandomNumberGenerator random;

        public RandomStrategy(IRandomNumberGenerator random)
        {
            this.random = random;
        }
        public IProvider SelectProvider(IList<IProvider> providers)
        {
            return providers[random.Next(0, providers.Count)];
        }
    }
}
