using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Repositories.RestClient
{
    public class CoinMarketClient
    {
        private readonly HttpClient _instance;
        public CoinMarketClient(string coinMarketCapAPIKey, string coinMarketCapURI)
        {
            _instance = new HttpClient { BaseAddress = new Uri(coinMarketCapURI) };
            _instance.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapAPIKey);
            _instance.DefaultRequestHeaders.Add("Accepts", "application/json");
        }

        public async Task<double> GetCurrentPrice(string shortname)
        {
            var addToUrl = "cryptocurrency/quotes/latest?symbol=" + shortname + "&convert=EUR";
            var response = await _instance.GetAsync(addToUrl);
            dynamic result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            JToken token = JObject.Parse(await response.Content.ReadAsStringAsync());
            double price = (double)token.SelectToken("data").SelectToken(shortname).SelectToken("quote").SelectToken("EUR").SelectToken("price");

            return price;
        }
    }
}
