using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public class CryptocurrencyRepository : IRepository<Cryptocurrency>
    {
        private readonly OlavCryptoRestClient _client;

        public CryptocurrencyRepository(OlavCryptoRestClient client)
        {
            _client = client;
        }

        public bool Create(Cryptocurrency item)
        {
            return _client.CreateData(EndPoints.Cryptocurrency, item);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Cryptocurrency>> Get()
        {
            return _client.GetData<Cryptocurrency>(EndPoints.Cryptocurrency);
        }

        public bool Update(Cryptocurrency item)
        {
            return _client.UpdateData(EndPoints.Cryptocurrency, item);
        }
    }
}
