using EntityAuth.Core.Contracts;
using EntityAuth.Shared.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Uttils
{
    public static class ServiceFilterExtensions
    {
        public static IQueryable<T> SetAclFilter<T>(this IQueryable<T> entities, IRepositoryFilter repository, AccessType accessType)
        {
            return repository.SetAclFilter(entities, accessType);
        }

        public static bool HasAccess<T>(this T entity, IRepositoryFilter repository, AccessType accessType)
        {
            return repository.HasAccess(entity, accessType);
        }

        public static bool HasAccess<T>(this IEnumerable<T> entity, IRepositoryFilter repository, AccessType accessType)
        {  
            return repository.HasAccess(entity, accessType);
        }
    }
}
