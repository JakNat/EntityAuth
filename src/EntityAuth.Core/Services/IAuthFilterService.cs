using EntityAuth.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Services
{
    public interface IAuthFilterService<T> 
    {
        IEnumerable<T> GetIds(Type type, AccessType accessType);
        IQueryable<T> GetIds(Type type, AccessType accessType, DbContext db);
    }
}