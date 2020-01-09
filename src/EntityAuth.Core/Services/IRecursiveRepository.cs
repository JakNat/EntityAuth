using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EntityAuth.Shared.Models;

namespace EntityAuth.Core.Services
{
    public interface IRoleRepository
    {
        void Add(Role parrent, Role child);
        void Add(string parentName, Role child);
        void Delete(string roleName);
        List<Role> Get(Expression<Func<Role, bool>> filter);
    }
}