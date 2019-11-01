using System;
using System.Linq;
using System.Threading.Tasks;
using CurrencyApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        /// Converting cash
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="codeFrom">Currency code which we want to convert</param>
        /// <param name="codeTo">Currency code which we want</param>
        [HttpGet("{amount}/{codeFrom}/{codeTo}")]
        public async Task<IActionResult> Get(decimal amount, string codeFrom, string codeTo)
        {
            var rateFromMid = await _rateService.GetRateMid(codeFrom);
            var rateToMid = await _rateService.GetRateMid(codeTo);

            if (rateFromMid == default || rateToMid == default)
                return  NotFound();

            var ratio = rateFromMid / rateToMid;

            return Ok(amount * ratio);
        }

        /// <summary>
        /// Browse all Currencies from 'a' table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> BrowseCurrencies()
        {
            var rates = await _rateService.GetRates();
            
            return Ok(rates);
        }

        /// <summary>
        /// Browse all rates from 'c' table
        /// </summary>
        /// <param name="currencyCodes">Currency codes as one string => "{currencyCode1}%{CurrenyCode2}..."</param>
        [HttpGet("list/{currencyCodes}")]
        public async Task<IActionResult> BrowseDetailedCurrencies(string currencyCodes)
        {
            var currencyCodess = currencyCodes.Split("%").Select(x => x.ToLower());

            var rates = (await _rateService.GetDetailedRates())
                .Where(x => currencyCodess.Contains(x.Code.ToLower()));
            
            return Ok(rates);
        }
    }
}
