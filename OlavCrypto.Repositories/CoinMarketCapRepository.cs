using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OlavCrypto.Repositories.RestClient;
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
        private readonly CoinMarketClient _client;

        public CoinMarketCapRepository(CoinMarketClient client)
        {
            _client = client;
        }

        public async Task GetCurrentPrice(string shortname)
        {
            await _client.GetCurrentPrice(shortname);
        }
    }
}
