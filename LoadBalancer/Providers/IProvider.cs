using System.Threading.Tasks;

namespace LoadBalancer.Providers
{
    public interface IProvider
    {
        Task<string> Get();
        bool Check(); // should be async too
    }
}
