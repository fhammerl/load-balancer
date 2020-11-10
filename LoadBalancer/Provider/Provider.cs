namespace LoadBalancer
{
    public interface IProvider
    {
        string Get();
    }

    public class Provider : IProvider
    {
        private string id;

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
