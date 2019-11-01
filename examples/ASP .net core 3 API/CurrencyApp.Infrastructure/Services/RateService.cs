using CurrencyApp.Core.Models;
using CurrencyApp.Infrastructure.ApiClient;
using CurrencyApp.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Infrastructure.Services
{
    public class RateService : IRateService
    {
        private readonly INbpRestClient _nbpRestClient;

        public RateService(INbpRestClient nbpRestClient)
        {
            _nbpRestClient = nbpRestClient;
        }


        public async Task<IEnumerable<RateDto>> GetRates()
        {
            var rates = await _nbpRestClient
                .FromTable(Table.a)
                .GetRates();

            return rates.Select(x => new RateDto()
            {
                Code = x.Code,
                Currency = x.Currency
            });
        }

        public async Task<IEnumerable<RateDetailedDto>> GetDetailedRates()
        {
            var rates = await _nbpRestClient
                .FromTable(Table.c)
                .GetRates();

            return rates.Select(x => new RateDetailedDto()
            {
                Code = x.Code,
                Currency = x.Currency,
                Ask = x.Ask,
                Bid = x.Bid
            });
        }

        public async Task<decimal> GetRateMid(string code)
        {
            var rate = await _nbpRestClient
                .FromTable(Table.a)
                .GetRateByCode(code);

            return rate.Mid;
        }
    }
}
