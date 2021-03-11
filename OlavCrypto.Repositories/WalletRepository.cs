using OlavCrypto.Models;
using OlavCrypto.Repositories.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IList<Wallet>> Get()
        {
            return _client.GetData<Wallet>(EndPoints.Wallet);
        }

        public bool Update(Wallet item)
        {
            return _client.UpdateData(EndPoints.Wallet, item);
        }
    }
}
