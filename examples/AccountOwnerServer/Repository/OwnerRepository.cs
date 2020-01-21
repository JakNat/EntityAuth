using Contracts;
using Entities;
using Entities.Models;
using EntityAuth.Core.Uttils;
using EntityAuth.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository 
    { 
        public OwnerRepository(RepositoryContext repositoryContext, IEntityFilter entityFilter) 
            : base(repositoryContext, entityFilter) 
        { 
        }

        public IEnumerable<Owner> GetAllOwners(bool aclSecured = false) 
        { 
            return FindAll(aclSecured)
                .OrderBy(ow => ow.Name)
                .ToList(); 
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}
