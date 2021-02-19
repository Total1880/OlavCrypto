using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System.Collections.Generic;

namespace OlavCrypto.Repositories
{
    public class WalletRepository : IRepository<Wallet>
    {
        private readonly OlavCryptoRestClient _client;

        public WalletRepository(OlavCryptoRestClient client)
        {
            _client = client;
        }
        public bool Create(Wallet item)
        {
            return _client.CreateData(EndPoints.Wallet, item);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Wallet> Get()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Wallet item)
        {
            return _client.UpdateData(EndPoints.Wallet, item);
        }
    }
}
