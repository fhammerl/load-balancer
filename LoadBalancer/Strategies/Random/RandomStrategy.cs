using LoadBalancer.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoadBalancer.LoadBalancer.Strategies
{
    public class RandomLoadBalancerStrategy : ILoadBalancerStrategy
    {
        public IProvider SelectProvider(IList<IProvider> providers)
        {
            throw new NotImplementedException();
        }
    }
}
