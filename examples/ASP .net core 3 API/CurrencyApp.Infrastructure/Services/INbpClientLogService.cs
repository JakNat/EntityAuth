using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyApp.Core.Entites;

namespace CurrencyApp.Infrastructure.Services
{
    public interface INbpClientLogService
    {
        Task<IEnumerable<NbpClientLogItem>> Get();
        Task Log(NbpClientLogItem nbpClientLogItem);
    }
}