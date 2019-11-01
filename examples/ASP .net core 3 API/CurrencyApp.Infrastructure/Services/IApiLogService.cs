using System.Collections.Generic;
using System.Threading.Tasks;
using EntityAuth.Core;
using CurrencyApp.Core.Entites;

namespace CurrencyApp.Infrastructure.Services
{
    public interface IApiLogService
    {
        Task<IEnumerable<ApiLogItem>> Get();
        Task Log(ApiLogItem apiLogItem);
    }
}