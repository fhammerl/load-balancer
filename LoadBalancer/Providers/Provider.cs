using System.Threading.Tasks;

namespace LoadBalancer.Providers
{
    public class Provider : IProvider
    {
        private readonly string id;

        public Provider(string id)
        {
            this.id = id;
        }

        public bool Check()
        {
            return true;
        }

        public async Task<string> Get()
        {
            return await Task.FromResult(id);
        }
        public override string ToString()
        {
            return $"Provider_{id}";
        }
    }
}
