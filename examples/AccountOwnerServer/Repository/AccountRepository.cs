using Contracts;
using Entities;
using Entities.Models;
using EntityAuth.Core.Uttils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository 
    { 
        public AccountRepository(RepositoryContext repositoryContext, IEntityFilter entityFilter) 
            : base(repositoryContext, entityFilter) 
        { 
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        { 
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList(); 
        }
    }
}
