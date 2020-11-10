namespace LoadBalancer.Tests
{
    class DummyLoadBalancer : LoadBalancer
    {
        public DummyLoadBalancer(IProviderRegistry providerRegistry) : base(providerRegistry)
        {
        }

        public override string Get()
        {
            throw new System.NotImplementedException();
        }
    }
}