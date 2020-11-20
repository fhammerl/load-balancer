using LoadBalancer.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace LoadBalancer.Heartbeat
{
    public interface IHeartbeatChecker
    {
        void Start();
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
                    Console.WriteLine($"Healtcheck: Provider excluded: {provider}");
                    providerRegistry.Exclude(provider);
                    unhealthyProviders[provider] = 0;
                }
                else
                {
                    Console.WriteLine($"Healtcheck: Provider remains active: {provider}");
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
                        Console.WriteLine($"Healtcheck: Provider included: {provider}");
                    }
                    else
                    {
                        Console.WriteLine($"Healtcheck: Provider passed health check but remains inactive: {provider}");
                    }
                }
                else
                {
                    unhealthyProviders[provider] = 0;
                    Console.WriteLine($"Healtcheck: Provider failed health check: {provider}");
                }
            }
        }
    }
}
