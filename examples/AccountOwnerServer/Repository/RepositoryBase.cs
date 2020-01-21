using Contracts;
using Entities;
using EntityAuth.Core.Contracts;
using EntityAuth.Core.Uttils;
using EntityAuth.Shared;
using EntityAuth.Shared.Enums;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IEntityFilter entityFilter;
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext, IEntityFilter entityFilter)
        {
            RepositoryContext = repositoryContext;
            this.entityFilter = entityFilter;
            
        }

        public IQueryable<T> FindAll(bool AclSecured = false)
        {
            var owners = FindAll();

            if (AclSecured)
                owners = SetAclFilter(owners, AccessType.GET);

            return owners;
        }


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool aclSecured = false)
        {
            var owners = FindByCondition(expression);

            if (aclSecured)
                owners = entityFilter.SetAclFilter(owners, AccessType.GET);

            return owners;
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity, bool aclSecured = false)
        {
            if (entityFilter.HasAccess(entity, AccessType.UPDATE))
                Update(entity);
        }

        public void Delete(T entity, bool aclSecured = false)
        {
            if (entityFilter.HasAccess(entity, AccessType.DELETE))
                Delete(entity);
        }


        public IQueryable<T> SetAclFilter<T>(IQueryable<T> entities, AccessType accessType)
        {
            return entityFilter.SetAclFilter(entities, accessType, RepositoryContext);
        }
    }
}