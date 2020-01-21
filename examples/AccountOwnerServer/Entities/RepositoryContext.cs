using Entities.Models;
using EntityAuth.Core;
using EntityAuth.Core.Aspects;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) 
            : base(options) 
        { 
        }

        // entityAuth
        [AuthFilter]
        public DbSet<Owner> Owners { get; set; }

        // entityAuth
        [AuthFilter]
        public DbSet<Account> Accounts { get; set; }

        // entityAuth
        [AclTables(typeof(Guid))]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
