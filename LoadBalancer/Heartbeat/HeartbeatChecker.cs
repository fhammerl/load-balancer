using LoadBalancer.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace LoadBalancer.Heartbeat
{
    public interface IHeartbeatChecker
    {
    }

    public class HeartbeatChecker : IHeartbeatChecker
    {
        private readonly IProviderRegistry providerRegistry;
        private readonly IScheduler scheduler;
        private const int consHealthCheckToInclude = 2;

        private Dictionary<IProvider, int> unhealthyProviders = new Dictionary<IProvider, int>();

        public HeartbeatChecker(IProviderRegistry providerRegistry, IScheduler scheduler)
        {
            this.providerRegistry = providerRegistry;
            this.scheduler = scheduler;
        }

        public void Start()
        {
            scheduler.Elapsed += HealthCheck;
            scheduler.Start();
        }

        private void HealthCheck(object source, ElapsedEventArgs e)
        {
            // .ToList() copies the list so that items moving from activeProviders to excludedProviders aren't checked twice
            var activeProviders = providerRegistry.ActiveProviders.ToList();
            var excludedProviders = providerRegistry.ExcludedProviders.ToList();

            CheckActiveProviders(activeProviders);
            CheckExcludedProviders(excludedProviders);
        }

        private void CheckActiveProviders(List<IProvider> activeProviders)
        {
            foreach (var provider in activeProviders)
            {
                if (!provider.Check())
                {
                    providerRegistry.Exclude(provider);
                    unhealthyProviders[provider] = 0;
                }
            }
        }

        private void CheckExcludedProviders(List<IProvider> excludedProviders)
        {
            foreach (var provider in excludedProviders)
            {
                if (provider.Check())
                {                    
                    unhealthyProviders[provider] += 1;
                    if (unhealthyProviders[provider] == consHealthCheckToInclude)
                    {
                        providerRegistry.Include(provider);
                    }
                } else
                {
                    unhealthyProviders[provider] = 0;
                }
            }
        }
    }
}
