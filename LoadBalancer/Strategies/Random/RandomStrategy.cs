using LoadBalancer.Providers;
using System;
using System.Collections.Generic;

namespace LoadBalancer.LoadBalancer.Strategies
{
    public class RandomLoadBalancerStrategy : ILoadBalancerStrategy
    {
        private readonly IRandomNumberGenerator random;

        public RandomLoadBalancerStrategy(IRandomNumberGenerator random)
        {
            this.random = random;
        }
        public IProvider SelectProvider(IList<IProvider> providers)
        {
            throw new NotImplementedException();
        }
    }
}
