using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public class CryptocurrencyDetailsRepository : IRepository<CryptocurrencyDetails>
    {
        private readonly OlavCryptoRestClient _client;

        public CryptocurrencyDetailsRepository(OlavCryptoRestClient client)
        {
            _client = client;
        }

        public bool Create(CryptocurrencyDetails item)
        {
            return _client.CreateData(EndPoints.CryptocurrenyDetails, item);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CryptocurrencyDetails>> Get()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CryptocurrencyDetails item)
        {
            throw new System.NotImplementedException();
        }
    }
}
