using LoadBalancer.Providers;
using System.Collections.Generic;

namespace LoadBalancer.LoadBalancer.Strategies
{
    public class RoundRobinStrategy : ILoadBalancerStrategy
    {
        private int counter = 0;

        public RoundRobinStrategy()
        {
        }
        public IProvider SelectProvider(IList<IProvider> providers)
        {
            var provider = providers[counter % providers.Count];
            counter++;
            return provider;
        }
    }
}
