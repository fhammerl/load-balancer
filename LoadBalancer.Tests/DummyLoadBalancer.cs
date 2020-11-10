namespace LoadBalancer.Tests
{
    class DummyLoadBalancer : LoadBalancer
    {
        public override string Get()
        {
            throw new System.NotImplementedException();
        }
    }
}