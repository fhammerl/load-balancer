using LoadBalancer.Providers;
using System.Collections.Generic;

namespace LoadBalancer.Core
{
    public abstract class AbstractLoadBalancer : ILoadBalancer
    {
        protected readonly IProviderRegistry providerRegistry;

        public AbstractLoadBalancer(IProviderRegistry providerRegistry)
        {
            this.providerRegistry = providerRegistry;
        }

        public void Register(IList<IProvider> providers)
        {

        }

        public abstract string Get();
    }
}
