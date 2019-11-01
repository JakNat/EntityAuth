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

        //[AuthFilter]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity()
            //modelBuilder.Entity<Blog>().Property<string>("TenantId").HasField("_tenantId");

            //// Configure entity filters
            //modelBuilder.Entity<Blog>().HasQueryFilter(b => EF.Property<string>(b, "TenantId") == _tenantId);
            //modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
        }


    }
}
