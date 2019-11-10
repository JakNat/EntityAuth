using EntityAuth.Core;
using CurrencyApp.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EntityAuth.Shared.Models;
using EntityAuth.Core.Aspects;

namespace CurrencyApp.Infrastructure.DAL
{
    [Authorization(typeof(long))]
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options)
        {
        }

        [AuthFilter]
        public DbSet<ApiLogItem> ApiLogs { get; set; }
        public DbSet<NbpClientLogItem> NbpClientLogs { get; set; }

        [AclTables(typeof(long))]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
