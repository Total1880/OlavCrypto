using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Repositories
{
    class WalletRepository : IRepository<Wallet>
    {
        public bool Create(Wallet item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.WalletList.Add(item);
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
                context.WalletList.Remove(context.WalletList.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<Wallet> Get()
        {
            using var context = new OlavCryptoContext();
            return context.WalletList.ToList();
        }

        public bool Update(Wallet item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.WalletList.Attach(item);
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
