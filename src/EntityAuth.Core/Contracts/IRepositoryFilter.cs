using EntityAuth.Core.Uttils;
using EntityAuth.Shared.Enums;
using System.Linq;

namespace EntityAuth.Core.Contracts
{
    public interface IRepositoryFilter
    {
        IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType);

        public bool HasAccess<T>(T entity, AccessType accessType);
    }
}
