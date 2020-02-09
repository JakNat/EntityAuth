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
            if (true)
            {
                var query = FindAll(true)
                .OrderBy(ow => ow.Name)
                .Include(ac => ac.Accounts)
                .Where(x => x.Accounts.Count > 10);

                return query.Include(x => x.Accounts).ToList();
            }
            else if (true)
            {
                return FindByCondition(owner => owner.DateOfBirth > DateTime.Now.AddYears(-10))
               .OrderByDescending(ow => ow.Name)
               .Include(ac => ac.Accounts)
               .Where(x => x.Accounts.Count < 10)
               .ToList();
            }
            else if (true)
            {
                return FindByCondition(owner => owner.DateOfBirth > DateTime.Now.AddYears(-20))
              .OrderByDescending(ow => ow.Name)
              .Include(ac => ac.Accounts)
              .Where(x => x.Accounts.Count < 4)
              .ToList();
            }
            else if (true)
            {
                return FindByCondition(owner => owner.DateOfBirth > DateTime.Now.AddYears(-10))
              .OrderByDescending(ow => ow.Name)
              .Include(ac => ac.Accounts)
              .Where(x => x.Accounts.Count < 10)
              .ToList();
            }
            else if (true)
            {
                return FindByCondition(owner => owner.DateOfBirth > DateTime.Now.AddYears(-10))
             .OrderByDescending(ow => ow.Name)
             .Include(ac => ac.Accounts)
             .Where(x => x.Accounts.Count < 10)
             .ToList();
            }

            return FindAll(aclSecured)
                .OrderBy(ow => ow.Name)
                .Include(ac => ac.Accounts)
                .ToList();
        }

        public Owner GetOwnerByName(string name, bool aclSecured)
        {
            return FindByCondition(owner => owner.Name == name, aclSecured)
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
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
