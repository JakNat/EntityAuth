using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool aclSecured = false); 
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool aclSecured = false); 
        void Create(T entity); 
        void Update(T entity, bool aclSecured = false); 
        void Delete(T entity, bool aclSecured = false);
    }
}
