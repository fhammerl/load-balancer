using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadBalancer
{
    public interface IProviderRegistry
    {
        void Register(IList<Provider> providers);
        IList<Provider> Providers { get; }
    }
    public class ProviderRegistry : IProviderRegistry
    {
        public IList<Provider> Providers { get; set; }
        const int MaxLength = 10; // TODO: Should come from a config file

        IList<Provider> IProviderRegistry.Providers => throw new NotImplementedException();

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
    }
}
