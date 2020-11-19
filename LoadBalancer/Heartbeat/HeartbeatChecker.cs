using LoadBalancer.Providers;
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
            foreach (var provider in providerRegistry.ActiveProviders)
            {
                if (!provider.Check())
                {
                    providerRegistry.Exclude(provider);
                }
            }
        }
    }
}
