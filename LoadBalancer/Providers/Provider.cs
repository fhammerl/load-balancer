namespace LoadBalancer.Providers
{
    public interface IProvider
    {
        string Get();
        bool Check();
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
        public bool Check()
        {
            return true;
        }
    }
}
