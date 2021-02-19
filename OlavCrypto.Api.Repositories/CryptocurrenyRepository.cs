using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Repositories
{
    class CryptocurrenyRepository : IRepository<Cryptocurrency>
    {
        public bool Create(Cryptocurrency item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyList.Add(item);
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
                context.CryptocurrencyList.Remove(context.CryptocurrencyList.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<Cryptocurrency> Get()
        {
            using var context = new OlavCryptoContext();
            return context.CryptocurrencyList.ToList();
        }

        public bool Update(Cryptocurrency item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyList.Attach(item);
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
