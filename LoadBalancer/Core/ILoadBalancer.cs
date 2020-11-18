using LoadBalancer.Providers;
using System.Collections.Generic;

namespace LoadBalancer.Core
{
    public interface ILoadBalancer : IProvider
    {
        void Register(IList<IProvider> providers);
    }
}
