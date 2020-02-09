using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace EntityAuth.Core.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext db;
        private readonly IMemorizeService memorizeService;

        public RoleRepository(DbContext db, IMemorizeService memorizeService)
        {
            this.db = db;
            this.memorizeService = memorizeService;
        }

        #region Get
        public IEnumerable<Role> Get(Expression<Func<Role, bool>> expression)
        {
            IQueryable<Role> parents = db.Set<Role>()
                .Include(x => x.Children)
                .Where(expression);

            foreach (Role entity in parents)
            {
                if (memorizeService.Contains(entity))
                    yield return memorizeService.Get(entity);
                LoadChildren(entity);

                yield return entity;
            }
        }
        private void LoadChildren(Role parent)
        {
            if (memorizeService.Contains(parent))
                parent = memorizeService.Get(parent);
            else
            {
                db.Entry(parent).Collection(e => e.Children).Query().Load();

                if (parent.Children != null)
                {
                    foreach (Role child in parent.Children)
                    {
                        LoadChildren(child);
                    }
                }

                memorizeService.Add(parent);
            }
        }

        public IEnumerable<Role> GetWithOffspring(Expression<Func<Role, bool>> filter)
        {

            var role = db.Set<Role>().Include(x => x.Children).FirstOrDefault(filter);
            
            if (role == null)
                return null;

            var results = GetOffspring(role);
            return results.Append(role);
        }

        private IEnumerable<Role> GetOffspring(Role parent)
        {
            if (memorizeService.ContainsChildren(parent))
                return memorizeService.GetChildren(parent);
            else
            {
                db.Entry(parent).Collection(e => e.Children).Query().Load();
                var children = new List<Role>();
                if (parent.Children != null)
                {
                    foreach (Role child in parent.Children)
                    {
                        children.Add(child);
                        children.AddRange(GetOffspring(child));
                    }
                }

                memorizeService.AddChildren(parent, children);
                return children;
            }
        }
        #endregion

        #region Add

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

            SaveChanges();
        }

        public void Add(string parentName, Role child)
        {
            var roles = db.Set<Role>();

            var parent = roles.FirstOrDefault(x => x.Name == parentName);

            Add(parent, child);
        }

        public void Add(string parentName, string childName)
        {
            var roles = db.Set<Role>();

            var parent = roles.FirstOrDefault(x => x.Name == parentName);
            var child = new Role() { Name = childName };

            Add(parent, child);
        }

        #endregion

        #region Delete

        public void Delete(string roleName)
        {
            var role = db.Set<Role>().FirstOrDefault(x => x.Name == roleName);

            Delete(role);
        }

        public void Delete(Role role)
        {
            if (role == null)
                return;

            rolesToDelete = new List<Role>();
            rolesToDelete.Add(role);

            if (role.Children != null)
                DeleteChildren(role);

            db.Set<Role>().RemoveRange(rolesToDelete);
            SaveChanges();
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

        #endregion

        private void SaveChanges()
        {
            memorizeService.Clear();
            db.SaveChanges();
        }

        #region private fields

        private List<Role> rolesToDelete;

        #endregion
    }
}
