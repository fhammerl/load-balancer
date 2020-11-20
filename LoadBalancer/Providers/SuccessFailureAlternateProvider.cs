using System.Threading.Tasks;

namespace LoadBalancer.Providers
{
    public class SuccessFailureAlternateProvider : IProvider
    {
        private readonly string id;
        private int sameConsecutiveChecks;
        private int checkCounter = 0;
        private bool successful = true;

        public SuccessFailureAlternateProvider(string id, int sameConsecutiveChecks)
        {
            this.id = id;
            this.sameConsecutiveChecks = sameConsecutiveChecks;
        }

        public bool Check()
        {
            checkCounter += 1;
            if (checkCounter == sameConsecutiveChecks)
            {
                checkCounter = 0;
                successful = !successful;
            }
            return successful;
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
