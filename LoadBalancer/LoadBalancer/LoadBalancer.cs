using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadBalancer
{
    public interface ILoadBalancer : IProvider
    {
        void Register(IList<Provider> providers);
    }

    public abstract class LoadBalancer : ILoadBalancer
    {
        protected IList<Provider> Providers;
        const int MaxLength = 10;

        public void Register(IList<Provider> providers)
        {
            if (providers.Count > MaxLength)
            {
                throw new ArgumentException($"Can't have more than {MaxLength} providers");
            }
            if (!providers.Any())
            {
                throw new ArgumentException($"Can't have 0 providers");
            }
            Providers = providers;
        }

        public abstract string Get();
    }
}
