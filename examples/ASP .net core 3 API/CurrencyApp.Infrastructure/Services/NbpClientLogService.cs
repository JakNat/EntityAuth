using CurrencyApp.Core.Entites;
using CurrencyApp.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyApp.Infrastructure.Services
{
    public class NbpClientLogService : INbpClientLogService
    {
        private readonly CurrencyDbContext _db;

        public NbpClientLogService(CurrencyDbContext db)
        {
            _db = db;
        }

        public async Task Log(NbpClientLogItem nbpClientLogItem)
        {
            _db.NbpClientLogs.Add(nbpClientLogItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<NbpClientLogItem>> Get()
        {
            var items = _db.NbpClientLogs;

            return await items.ToListAsync();
        }

    }
}
