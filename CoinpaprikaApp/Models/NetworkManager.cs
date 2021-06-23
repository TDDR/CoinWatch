using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinpaprikaApp.Models
{
    public class NetworkManager
    {
        private string _url = "https://api.coinpaprika.com";
        private HttpClient _client = new HttpClient();

        public async Task<List<Coin>> GetAllCoins()
        {
            var response = await _client.GetAsync(_url + "/v1/coins");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Coin>();
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Coin>>(responseString);
            }
        }

        public async Task<Coin> GetCoinById(string id)
        {
            var response = await _client.GetAsync(_url + "/v1/coins/" + id);
            var responseString = await response.Content.ReadAsStringAsync();
            Coin coin = JsonConvert.DeserializeObject<Coin>(responseString);
            return coin;
        }
        public async Task<OhlcvToday> GetCurrentNumbers(string id)
        {
            var response = await _client.GetAsync(_url + "/v1/coins/" + id + "/ohlcv/today/");
            var responseString = await response.Content.ReadAsStringAsync();
            var ohlcvList = JsonConvert.DeserializeObject<List<OhlcvToday>>(responseString.ToString());
            return ohlcvList[0];
            
        }
    }
}
