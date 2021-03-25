using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public class CryptocurrencyWalletRepository : IRepository<CryptocurrencyWallet>
    {
        private readonly OlavCryptoRestClient _client;

        public CryptocurrencyWalletRepository(OlavCryptoRestClient client)
        {
            _client = client;
        }

        public bool Create(CryptocurrencyWallet item)
        {
            return _client.CreateData(EndPoints.CryptoCurrencyWallet, item);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CryptocurrencyWallet>> Get()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CryptocurrencyWallet item)
        {
            throw new System.NotImplementedException();
        }
    }
}
