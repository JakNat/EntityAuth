using CurrencyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Infrastructure.ApiClient
{
    public interface INbpTable
    {
        Task<IEnumerable<Rate>> GetRates();
        Task<Rate> GetRateByCode(string table);
    }
}
