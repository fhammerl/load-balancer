using LoadBalancer.Heartbeat;
using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadBalancer.Core
{
    public class DefaultLoadBalancer : AbstractLoadBalancer
    {
        private readonly ILoadBalancerStrategy strategy;
        private readonly IHeartbeatChecker heartbeatChecker;

        public DefaultLoadBalancer(IProviderRegistry providerRegistry, ILoadBalancerStrategy strategy, IHeartbeatChecker heartbeatChecker) : base(providerRegistry)
        {
            this.strategy = strategy;
            this.heartbeatChecker = heartbeatChecker;
        }

        public override void Register(IList<IProvider> providers)
        {
            base.Register(providers);
            heartbeatChecker.Start();
        }

        public override bool Check()
        {
             // LoadBalancer are planned to have a queue for incoming requests
             // Regardless of their provider's health, they're always considered to be up
            return true;
        }

        public override Task<string> Get()
        {
            var provider = strategy.SelectProvider(providerRegistry.ActiveProviders);
            return provider.Get(); // Null check? Null Object pattern?
        }
    }
}
