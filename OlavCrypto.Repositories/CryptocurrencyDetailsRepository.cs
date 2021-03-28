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
            return _client.CreateData(EndPoints.CryptocurrencyDetails, item);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CryptocurrencyDetails>> Get()
        {
            return _client.GetData<CryptocurrencyDetails>(EndPoints.CryptocurrencyDetails);
        }

        public bool Update(CryptocurrencyDetails item)
        {
            return _client.UpdateData(EndPoints.CryptocurrencyDetails, item);
        }
    }
}
