using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityAuth.Core.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext db;

        public RoleRepository(DbContext db)
        {
            this.db = db;
        }

        private List<Role> results;
        private List<Role> rolesToDelete;

        /// <summary>
        /// Get role with its offspring
        /// </summary>
        public List<Role> Get(Expression<Func<Role, bool>> filter)
        {
            var roles = db.Set<Role>().Include(x => x.Children).ToList();

            results = new List<Role>();
            foreach (Role entity in db.Set<Role>().Include(x => x.Children).Where(filter))
            {
                results.Add(entity);
                GetChildren(entity, filter);

            }

            return results;
        }

        public void Add(Role parrent, Role child)
        {

            if (parrent != null)
            {
                if (parrent.Children == null)
                    parrent.Children = new List<Role>();

                parrent.Children.Add(child);
                db.Set<Role>().Update(parrent);
            }
            else
            {
                db.Set<Role>().Add(child);
            }

            db.SaveChanges();
        }

        public void Add(string parentName, Role child)
        {
            var roles = db.Set<Role>();

            var parent = roles.FirstOrDefault(x => x.Name == parentName);

            Add(parent, child);
        }

        /// <summary>
        /// delete role and its offspring
        /// </summary>
        public void Delete(string roleName)
        {
            var role = db.Set<Role>().FirstOrDefault(x => x.Name == roleName);

            if (role == null)
                return;

            rolesToDelete = new List<Role>();
            rolesToDelete.Add(role);

            if (role.Children != null)
                DeleteChildren(role);

            db.Set<Role>().RemoveRange(rolesToDelete);
            db.SaveChanges();
        }

        private void DeleteChildren(Role parent)
        {
            db.Entry(parent).Collection(e => e.Children).Query().Load();

            if (parent.Children != null)
            {
                foreach (Role child in parent.Children)
                {
                    rolesToDelete.Add(child);
                    DeleteChildren(child);
                }
            }
        }

        private void GetChildren(Role parent, Expression<Func<Role, bool>> childFilter)
        {
            db.Entry(parent).Collection(e => e.Children).Query().Where(childFilter).Load();

            if (parent.Children != null)
            {
                foreach (Role child in parent.Children)
                {
                    results.Add(child);
                    GetChildren(child, childFilter);
                }
            }
        }
    }
}
