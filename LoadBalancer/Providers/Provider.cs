using System.Threading.Tasks;

namespace LoadBalancer.Providers
{
    public interface IProvider
    {
        Task<string> Get();
        bool Check(); // should be async too
    }

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
    }
}
