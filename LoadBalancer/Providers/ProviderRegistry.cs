using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadBalancer.Providers
{
    public interface IProviderRegistry
    {
        void Register(IList<IProvider> providers);
        IList<IProvider> Providers { get; }
    }
    public class ProviderRegistry : IProviderRegistry
    {
        public IList<IProvider> Providers { get; set; }
        const int MaxLength = 10; // TODO: Should come from a config file

        IList<IProvider> IProviderRegistry.Providers => throw new NotImplementedException();

        public void Register(IList<IProvider> providers)
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
    }
}
