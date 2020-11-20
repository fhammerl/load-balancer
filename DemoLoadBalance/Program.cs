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
            Console.WriteLine("The demo uses a round robin load balancing strategy to distribute requests between providers Echo, Foxtrot and Golf.");
            Console.WriteLine("Every second, a new requests comes and the next in line provider picks it up.");
            Console.WriteLine("There is a health check every 3 seconds.");
            Console.WriteLine("Echo and Golf are stable but Foxtrot succeeds and fails health checks in alternating threes.");
            Console.WriteLine("Foxtrot is then temporarily removed from the avaliable providers.");
            Console.WriteLine("Press a key and read the logs to see the above story unfold.\n\n");
            Console.ReadKey(true);

            List<IProvider> providers = BuildProviders();
            lb.Register(providers);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Provider selected: {lb.Get().Result}");
                Thread.Sleep(1000);
            }

        }

        private static List<IProvider> BuildProviders()
        {
            return new List<IProvider>(new IProvider[]
            {
                new Provider("Echo"),
                new SuccessFailureAlternateProvider("Foxtrot", 3), // 3 successful checks, 3 failed, alternating
                new Provider("Golf")
            });
        }

        private static DefaultLoadBalancer BuildLoadBalancer() // TODO: include this in library? IOptions / IConfig object?
        {
            var registry = new ProviderRegistry();
            var strategy = new RoundRobinStrategy();
            var scheduler = new Scheduler(interval: 3000); // healthcheck scheduled every 3 seconds
            var heartbeatChecker = new HeartbeatChecker(registry, scheduler);
            var lb = new DefaultLoadBalancer(registry, strategy, heartbeatChecker);
            return lb;
        }
    }
}
