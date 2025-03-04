﻿using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlavCrypto.Api.Repositories
{
    public class CryptocurrencyDetailsRepository : IRepository<CryptocurrencyDetails>
    {
        public bool Create(CryptocurrencyDetails item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyDetailsList.Add(item);
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
                context.CryptocurrencyDetailsList.Remove(context.CryptocurrencyDetailsList.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<CryptocurrencyDetails> Get()
        {
            using var context = new OlavCryptoContext();
            return context.CryptocurrencyDetailsList.Include(x => x.CryptocurrencyWallet.Cryptocurrency).Include(x => x.CryptocurrencyWallet.Wallet).ToList();
        }

        public bool Update(CryptocurrencyDetails item)
        {
            try
            {
                using var context = new OlavCryptoContext();
                context.CryptocurrencyDetailsList.Attach(item);
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
