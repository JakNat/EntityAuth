using Microsoft.EntityFrameworkCore;
using System;
using Z.EntityFramework.Plus;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using EntityAuth.Core.Services;

namespace EntityAuth.Core
{
    public static class EFFilterExtensions
    {
        #region Set Filter for DbSet<> With AuthFilter attribute

        public static void SetFilter<T>(this DbContext context, Type entityType, IEnumerable<T> aclIds)
        {
            SetFilterMethod.MakeGenericMethod(entityType, typeof(T))
                .Invoke(null, new object[] { context , aclIds});
        }

        static readonly MethodInfo SetFilterMethod = typeof(EFFilterExtensions)
                   .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetFilter");

        private static void SetFilter<TEntity,T>(this DbContext context, IEnumerable<T> aclIds)
            where TEntity : class, IResourceId<T>
        {
            context.Filter<TEntity>(q => q.Where(x => aclIds.Contains(x.Id)));
        }

        #endregion

        #region Set Fitlers for all DbSet<> with AuthFIlter Attribute in DbContext

        public static void SetFilters(this DbContext context, Type identifierType, IServiceProvider serviceProvider, IEnumerable<PropertyInfo> dbSets)
        {
            SetFiltersMethod.MakeGenericMethod(identifierType)
                .Invoke(null, new object[] { context, serviceProvider, dbSets });
        }

        static readonly MethodInfo SetFiltersMethod = typeof(EFFilterExtensions)
                   .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetFilters");

        private static void SetFilters<TIdentifier>(this DbContext context, IServiceProvider serviceProvider, IEnumerable<PropertyInfo> dbSets)
        {
           
            var service = serviceProvider.GetService(typeof(IAuthFilterService<TIdentifier>))
                                 as IAuthFilterService<TIdentifier>;
           
            foreach (var dbSet in dbSets)
            {
                var type = dbSet.PropertyType.GenericTypeArguments[0];

                var aclIds = service.GetIds(type, context);

                context.SetFilter(type, aclIds);
            }
        }
        #endregion

        ///// <summary>
        ///// Modelling acl tables
        ///// </summary>
        ///// <typeparam name="T"> type of entity identifier</typeparam>
        //public static void SetAclTables<T>(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ResourceType>();
        //    modelBuilder.Entity<Role>();
        //    modelBuilder.Entity<Permission<T>>();
        //}

        public static EntityAuthTablesBuilder SetAclTablesBuilder(this ModelBuilder modelBuilder)
        {
            return new EntityAuthTablesBuilder().SetModelBuilder(modelBuilder);
        }
    }
}
