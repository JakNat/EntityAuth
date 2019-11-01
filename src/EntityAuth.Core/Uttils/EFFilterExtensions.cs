using Microsoft.EntityFrameworkCore;
using System;
using Z.EntityFramework.Plus;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace EntityAuth.Core
{
    public static class EFFilterExtensions
    {
        public static void SetFilter(this DbContext context, Type entityType, IEnumerable<int> aclIds)
        {
            SetFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { context , aclIds});
        }

        static readonly MethodInfo SetFilterMethod = typeof(EFFilterExtensions)
                   .GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetFilter");

        public static void SetFilter<TEntity>(this DbContext context, IEnumerable<int> aclIds)
            where TEntity : class, IPrimaryAuth
        {
            context.Filter<TEntity>(q => q.Where(x => aclIds.Contains(x.AclId)));
        }

        //public static DbSet<TEntity> Disable<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
        //{
        //    return dbSet.Disable();
        //}
    }
}
