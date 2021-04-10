using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyHistoryService
    {
        bool CreateCryptocurrencyHistory(CryptocurrencyHistory cryptocurrencyHistory);
        IList<CryptocurrencyHistory> GetCryptocurrencyHistories();
    }
}
