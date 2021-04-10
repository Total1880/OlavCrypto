using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    class CryptocurrenyHistoryRepository : IRepository<CryptocurrencyHistory>
    {
        private readonly OlavCryptoRestClient _client;

        public CryptocurrenyHistoryRepository(OlavCryptoRestClient client)
        {
            _client = client;
        }

        public bool Create(CryptocurrencyHistory item)
        {
            return _client.CreateData(EndPoints.CryptocurrencyHistory, item);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CryptocurrencyHistory>> Get()
        {
            return await _client.GetData<CryptocurrencyHistory>(EndPoints.CryptocurrencyHistory);
        }

        public bool Update(CryptocurrencyHistory item)
        {
            throw new NotImplementedException();
        }
    }
}
