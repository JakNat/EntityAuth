using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EntityAuth.Shared.Models;

namespace EntityAuth.Core.Services
{
    public interface IRoleRepository
    {
        void Add(Role parrent, Role child);
        void Add(string parentName, string child);
        void Add(string parentName, Role child);

        void Delete(string roleName);
        void Delete(Role role);

        /// <summary>
        /// Get roles with their offspring
        /// </summary>
        IEnumerable<Role> GetWithOffspring(Expression<Func<Role, bool>> filter);

        IEnumerable<Role> Get(Expression<Func<Role, bool>> filter);
    }
}