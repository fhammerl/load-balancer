using LoadBalancer.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadBalancer.Core
{
    public abstract class AbstractLoadBalancer : ILoadBalancer
    {
        protected readonly IProviderRegistry providerRegistry;

        public AbstractLoadBalancer(IProviderRegistry providerRegistry)
        {
            this.providerRegistry = providerRegistry;
        }

        public virtual void Register(IList<IProvider> providers)
        {
            providerRegistry.Register(providers);
        }

        public abstract Task<string> Get();
        public abstract bool Check();
    }
}
