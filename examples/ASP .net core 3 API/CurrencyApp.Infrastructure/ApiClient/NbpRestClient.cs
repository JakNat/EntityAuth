using CurrencyApp.Core.Entites;
using CurrencyApp.Core.Models;
using CurrencyApp.Infrastructure.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Infrastructure.ApiClient
{
    public class NbpRestClient : INbpRestClient, INbpTable
    {
        private readonly IRestClient _client;
        private readonly INbpClientLogService _nbpClientLogService;
        
        private Table _table;

        public NbpRestClient(IRestClient client, INbpClientLogService nbpClientLogService)
        {
            _client = client;
            _nbpClientLogService = nbpClientLogService;
        }

        public INbpTable FromTable(Table table)
        {
            _table = table;
            return this;
        }

        public async Task<T> Execute<T>(IRestRequest request) where T : new()
        {
            request.AddParameter("Table", _table.ToString(), ParameterType.UrlSegment); // used on every request

            var stopWatch = Stopwatch.StartNew();
            var requestTime = DateTime.UtcNow;

            var response = await _client.ExecuteTaskAsync<T>(request);

            stopWatch.Stop();

            var logItem = new NbpClientLogItem()
            {
                RequestTime = requestTime,
                ResponseMillis = stopWatch.ElapsedMilliseconds,
                ResponseUri = response.ResponseUri.ToString(),
                ResponseStatus = response.ResponseStatus.ToString()
                
            };
            await _nbpClientLogService.Log(logItem);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var npbException = new Exception(message, response.ErrorException);
                throw npbException;
            }

            return response.Data;
        }

        public async Task<IEnumerable<Rate>> GetRates()
        {
            var request = new RestRequest("/exchangerates/tables/{Table}/");
            var result = await Execute<List<ExchangeRatesTable>>(request);
          
            return result.FirstOrDefault()?.Rates;
        }

        public async Task<Rate> GetRateByCode(string code)
        {
            var request = new RestRequest("/exchangerates/rates/{Table}/{Code}/");
            request.AddParameter("Code", code, ParameterType.UrlSegment);
            var result = await Execute<ExchangeRateSeries>(request);

            return result.Rates.FirstOrDefault();
        }
    }
}
