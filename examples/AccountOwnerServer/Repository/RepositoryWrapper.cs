using Contracts;
using Entities;
using EntityAuth.Core.Uttils;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper 
    { 
        private RepositoryContext _repoContext;
        private readonly IEntityFilter entityFilter;
        private IOwnerRepository _owner; 
        private IAccountRepository _account; 
        public IOwnerRepository Owner 
        { 
            get 
            { 
                if (_owner == null) 
                { 
                    _owner = new OwnerRepository(_repoContext, entityFilter); 
                } 
                return _owner; 
            } 
        } 
        
        public IAccountRepository Account 
        { 
            get 
            { 
                if (_account == null) 
                { 
                    _account = new AccountRepository(_repoContext, entityFilter); 
                } 
                return _account; 
            } 
        } 
        
        public RepositoryWrapper(RepositoryContext repositoryContext, IEntityFilter entityFilter) 
        { 
            _repoContext = repositoryContext;
            this.entityFilter = entityFilter;
        } 
        
        public void Save() 
        {
            _repoContext.SaveChanges();
        } 
    }
}
