using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadBalancer.Providers
{
    public interface IProviderRegistry
    {
        void Register(IList<IProvider> providers);
        void Exclude(IProvider provider);
        void Include(IProvider provider);
        IList<IProvider> ActiveProviders { get; }
        IList<IProvider> ExcludedProviders { get; }
    }
    public class ProviderRegistry : IProviderRegistry
    {
        public IList<IProvider> ActiveProviders { get; private set; }
        public IList<IProvider> ExcludedProviders { get; private set; }
        const int MaxLength = 10; // TODO: Should come from a config file


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
            ExcludedProviders = new List<IProvider>();
            ActiveProviders = providers;
        }

        public void Exclude(IProvider provider)
        {
            if (ActiveProviders.Remove(provider))
            {
                ExcludedProviders.Add(provider);
            }
            else
            {
                throw new ArgumentException("Provider is not registered so it can't be excluded");
            }
        }

        public void Include(IProvider provider)
        {
            if (ExcludedProviders.Remove(provider))
            {
                ActiveProviders.Add(provider);
            }
            else
            {
                throw new ArgumentException("Provider is not registered so it can't be included");
            }
        }
    }
}
