using EntityAuth.Core.Services;
using EntityAuth.Shared.Enums;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityAuth.Core.Uttils
{
    public class EntityFilter : IEntityFilter
    {
        private readonly IEntityAuthConfiguration configuration;
        private readonly IServiceProvider serviceProvider;

        public EntityFilter(IEntityAuthConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.configuration = configuration;
            this.serviceProvider = serviceProvider;
        }

        public IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType, DbContext db)
        {
            return GetFilterFactory()
                .SetAclFilter(entities, accessType, db);
        }

        public IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType) { 
            return GetFilterFactory()
                .SetAclFilter(entities, accessType);
        }


        public bool HasAccess<T>(T entity, AccessType accessType)
        {
                return GetFilterFactory()
                .HasAccess(entity, accessType);
        }

        private IEntityFilterFactory GetFilterFactory()
        {
            if (configuration.IdentifierType == typeof(Guid))
                return GetFactory<Guid>();

            if (configuration.IdentifierType == typeof(int))
                return GetFactory<int>();

            if (configuration.IdentifierType == typeof(long))
                return GetFactory<long>();

            throw new Exception("Not supported identifier type");
        }

        private IEntityFilterFactory GetFactory<T>()
        {
            var authFilterService = serviceProvider
                .GetService(typeof(IAuthFilterService<T>))
                as IAuthFilterService<T>;

            return new EntityFilterFactory<T>(authFilterService);
        }
    }

    public class EntityFilterFactory<TIdentyfier> : IEntityFilterFactory
    {
        private readonly IAuthFilterService<TIdentyfier> authFilterService;

        public EntityFilterFactory(
            IAuthFilterService<TIdentyfier> authFilterService)
        {
            this.authFilterService = authFilterService;
        }

        public bool HasAccess<T>(T entity, AccessType accessType)
        {
            var ids = authFilterService.GetIds(typeof(T), accessType).ToList();

            return ids.Exists(x => x.Equals(((IResourceId<TIdentyfier>)entity).Id));
        }

        public IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType, DbContext db)
        {
            var ids = authFilterService.GetIds(typeof(T), accessType, db);

            return
                (from e in entities
                 join id in ids on ((IResourceId<TIdentyfier>)e).Id equals id
                 select e);
        }

        public IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType)
        {
            var idsInMemmory = authFilterService.GetIds(typeof(T), accessType).ToList();

            return entities.Where(x => idsInMemmory.Contains(((IResourceId<TIdentyfier>)x).Id));
        }
    }
}
