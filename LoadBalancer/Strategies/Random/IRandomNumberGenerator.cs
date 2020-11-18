namespace LoadBalancer.LoadBalancer.Strategies
{
    public interface IRandomNumberGenerator
    {
        int Next(int min, int max);
    }
}