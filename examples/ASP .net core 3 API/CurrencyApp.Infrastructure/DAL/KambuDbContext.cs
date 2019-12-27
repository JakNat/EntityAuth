using EntityAuth.Core;
using CurrencyApp.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApp.Infrastructure.DAL
{
    [Authorization]
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options)
        {
        }

        [AuthFilter]
        public DbSet<ApiLogItem> ApiLogs { get; set; }
        public DbSet<NbpClientLogItem> NbpClientLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
