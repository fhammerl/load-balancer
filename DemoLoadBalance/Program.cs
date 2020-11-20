using LoadBalancer.Core;
using LoadBalancer.Heartbeat;
using LoadBalancer.LoadBalancer.Strategies;
using LoadBalancer.Providers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DemoLoadBalance
{
    class Program
    {
        public static void Main(string[] args)
        {
            var lb = BuildLoadBalancer();

            var providers = new List<IProvider>(new IProvider[]
            {
                new Provider("Tango"),
                new Provider("Uniform"),
                new SuccessFailureAlternateProvider("November", 3),
                new Provider("Alfa")
            });
            lb.Register(providers);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Provider selected: {lb.Get().Result}");
                Thread.Sleep(1000);
            }

        }

        private static DefaultLoadBalancer BuildLoadBalancer() // TODO: include this in library? IOptions / IConfig object?
        {
            var registry = new ProviderRegistry();
            var strategy = new RoundRobinStrategy();
            var scheduler = new Scheduler(interval: 2000);
            var heartbeatChecker = new HeartbeatChecker(registry, scheduler);
            var lb = new DefaultLoadBalancer(registry, strategy, heartbeatChecker);
            return lb;
        }
    }
}
