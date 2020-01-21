using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityAuth.Core.Test
{
    public class TestDb<T> : DbContext
    {
        public TestDb(DbContextOptions<TestDb<T>> options) : base(options)
        {
        }

        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission<T>> Permissions { get; set; }
    }
}
