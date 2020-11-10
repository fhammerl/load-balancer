using System;

namespace LoadBalancer
{
    public class RandomLoadBalancer : LoadBalancer
    {
        public override string Get()
        {
            return this.Providers[new Random().Next(0, Providers.Count)].Get();
        }
    }
}
