using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyApp.Core.Models;
using CurrencyApp.Infrastructure.ApiClient;
using CurrencyApp.Infrastructure.Dto;

namespace CurrencyApp.Infrastructure.Services
{
    public interface IRateService
    {
        Task<decimal> GetRateMid(string code);
        Task<IEnumerable<RateDto>> GetRates();
        Task<IEnumerable<RateDetailedDto>> GetDetailedRates();
    }
}