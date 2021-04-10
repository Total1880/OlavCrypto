using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Repositories
{
    public class CryptocurrencyHistoryRepository : IRepository<CryptocurrencyHistory>
    {
        public bool Create(CryptocurrencyHistory item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyList.Attach(item.Cryptocurrency);
                context.CryptocurrencyHistoryList.Add(item);
                context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CryptocurrencyHistory> Get()
        {
            using var context = new OlavCryptoContext();
            return context.CryptocurrencyHistoryList.ToList();
        }

        public bool Update(CryptocurrencyHistory item)
        {
            throw new NotImplementedException();
        }
    }
}
