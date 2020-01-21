using EntityAuth.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityAuth.Core.Uttils
{
    public interface IEntityFilterFactory
    {
        bool HasAccess<T>(T entity, AccessType accessType);
        IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType);
        IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType, DbContext db);
    }
}