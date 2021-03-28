using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public class CoinMarketCapRepository : ICoinMarketCapRepository
    {
        private readonly HttpClient _instance;

        public CoinMarketCapRepository()
        {
            _instance = new HttpClient { BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/") };
            _instance.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "914b837d-f6d2-41a0-84b8-ef55c1a62186");
            _instance.DefaultRequestHeaders.Add("Accepts", "application/json");
        }

        public async Task GetCurrentPrice(string shortname)
        {
            var addToUrl = "cryptocurrency/quotes/latest?symbol=" + shortname;
            var response = await _instance.GetAsync(addToUrl);


            var test = response.Content.ReadAsStringAsync();
        }
    }
}
