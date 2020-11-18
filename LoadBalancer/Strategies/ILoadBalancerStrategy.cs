using LoadBalancer.Providers;
using System.Collections;
using System.Collections.Generic;

namespace LoadBalancer.LoadBalancer.Strategies
{
    public interface ILoadBalancerStrategy
    {
        IProvider SelectProvider(IList<IProvider> providers);
    }
}