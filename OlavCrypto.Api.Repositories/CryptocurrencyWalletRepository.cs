using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Repositories
{
    class CryptocurrencyWalletRepository : IRepository<CryptocurrencyWallet>
    {
        public bool Create(CryptocurrencyWallet item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyWalletList.Add(item);
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
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyWalletList.Remove(context.CryptocurrencyWalletList.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<CryptocurrencyWallet> Get()
        {
            using var context = new OlavCryptoContext();
            return context.CryptocurrencyWalletList.ToList();
        }

        public bool Update(CryptocurrencyWallet item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyWalletList.Attach(item);
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
