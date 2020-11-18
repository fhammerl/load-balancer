namespace LoadBalancer.Providers
{
    public interface IProvider
    {
        string Get();
    }

    public class Provider : IProvider
    {
        private readonly string id;

        public Provider(string id)
        {
            this.id = id;
        }
        public string Get()
        {
            return id;
        }
    }
}
