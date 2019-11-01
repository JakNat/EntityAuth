using EntityAuth.Core;
using CurrencyApp.Core.Entites;
using CurrencyApp.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityAuth.Core.Services;

namespace CurrencyApp.Infrastructure.Services
{
    public class ApiLogService : IApiLogService
    {
        private readonly CurrencyDbContext _db;
        private readonly IAuthorizationService authorizationService;

        public ApiLogService(CurrencyDbContext db, IAuthorizationService authorizationService)
        {
            _db = db;
            this.authorizationService = authorizationService;
        }

        public async Task Log(ApiLogItem apiLogItem)
        {
            var x2 = await _db.ApiLogs.ToListAsync();

            authorizationService.SetCurrentUser(3);
            _db.ApiLogs.Add(apiLogItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApiLogItem>> Get()
        {
            var items = _db.ApiLogs;
            return await items.ToListAsync();
        }
    }
}
