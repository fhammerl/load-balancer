using System.Collections.Generic;

namespace LoadBalancer
{
    public interface ILoadBalancer : IProvider
    {
        void Register(IList<Provider> providers);
    }

    public abstract class LoadBalancer : ILoadBalancer
    {
        protected readonly IProviderRegistry providerRegistry;

        public LoadBalancer(IProviderRegistry providerRegistry)
        {
            this.providerRegistry = providerRegistry;
        }

        public void Register(IList<Provider> providers)
        {

        }

        public abstract string Get();
    }


}
