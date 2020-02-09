using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners(bool aclSecured = false);
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerByName(string name, bool aclSecured = false);
        Owner GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
