using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TAFrontend.Models;
using TAFrontend.Services.Interfaces;

namespace TAFrontend.Services
{
    
    public class DailyInfoService: IDailyInfoService
    {
        private readonly string dbCommunicationService;
        private readonly HttpClient httpClient = new HttpClient();

        public DailyInfoService(string dbCommunicationService)
        {
            this.dbCommunicationService = dbCommunicationService;
        }

        public async Task<IEnumerable<Tickers>> GetTickersAsync()
        {
            var url = $"{this.dbCommunicationService}/TickerInfo/GetTickers";
            var response = await httpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStreamAsync();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var tickers = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Tickers>>(responseString, jsonOptions);
            return tickers;
        }

        public async Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTickerAsync(string ticker)
        {
            var baseUrl = $"{this.dbCommunicationService}/TickerInfo/GetDailyInfoByTicker";
            var tickerArg = new Dictionary<string, string>() { { "ticker", ticker } };
            var url = new Uri(QueryHelpers.AddQueryString(baseUrl, tickerArg));
            var response = await httpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStreamAsync();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var tickers = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<TickerDailyInfo>>(responseString, jsonOptions);
            return tickers;
        }
    }
}
