using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace OlavCrypto.Repositories.RestClient
{
    public class OlavCryptoRestClient
    {
        private readonly HttpClient _instance;


        public OlavCryptoRestClient(string baseAdress)
        {
            _instance = new HttpClient { BaseAddress = new Uri(baseAdress) };

        }
        public bool CreateData<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data).ToString();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _instance.PostAsync(endpoint, content);
            response.Wait();

            return response.Result.IsSuccessStatusCode;
        }

        public bool UpdateData<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data).ToString();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _instance.PutAsync(endpoint, content);
            response.Wait();

            return response.Result.IsSuccessStatusCode;
        }
    }
}
