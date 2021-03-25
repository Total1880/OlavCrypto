using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlavCrypto.Api.Repositories
{
    public class CryptocurrencyWalletRepository : IRepository<CryptocurrencyWallet>
    {
        public bool Create(CryptocurrencyWallet item)
        {
            try
            {
                using var context = new OlavCryptoContext();

                context.WalletList.Attach(item.Wallet);
                context.CryptocurrencyList.Attach(item.Cryptocurrency);
                context.CryptocurrencyWalletList.Add(item);

                context.SaveChanges();

                var newItem = new CryptocurrencyDetails { CryptocurrencyWallet = item };
                context.CryptocurrencyWalletList.Attach(newItem.CryptocurrencyWallet);
                context.CryptocurrencyDetailsList.Add(newItem);

                context.SaveChanges();

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
            return context.CryptocurrencyWalletList.Include(x => x.Cryptocurrency).Include(x => x.Wallet).ToList();
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
