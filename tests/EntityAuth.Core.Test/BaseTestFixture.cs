using System;
using System.Collections.Generic;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityAuth.Core.Test
{
    public class BaseTestFixture<T> : IDisposable
    {
        public DbContext Context { get; set; }

        public BaseTestFixture()
        {
            var builder = new DbContextOptionsBuilder<TestDb<T>>()
                    .UseInMemoryDatabase(databaseName: "database_name");

            Context = new TestDb<T>(builder.Options);
        }

        public void Dispose()
        {
        }
    }
}
