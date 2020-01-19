using EntityAuth.Shared.Enums;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Services
{
    public class AuthFilterService<T> : IAuthFilterService<T>
    {
        private readonly IAuthorizationService authorizationService;
        private readonly DbContext db;
        private readonly IRoleRepository recursiveRepository;

        public AuthFilterService(IAuthorizationService authorizationService,
            DbContext db, IRoleRepository recursiveRepository)
        {
            this.authorizationService = authorizationService;
            this.db = db;
            this.recursiveRepository = recursiveRepository;
        }

        public IQueryable<T> GetIds(Type type, AccessType accessType, DbContext db)
        {
            var roleName = authorizationService.GetCurrentRole();

            var roleIds = recursiveRepository
                .GetOffspring(x => x.Name == roleName)
                .Select(x => x.Id);

            var permissions = db.Set<Permission<T>>();

            return permissions
                 // cannot join roleIds because ef core doesn't support in memory collections
                 .Where(x => roleIds.Contains(x.RoleId) &&
                             x.ResourceType.Name == type.Name &&
                             x.AccessType == accessType)
                 .Select(x => x.ResourceId);
        }

        public IEnumerable<T> GetIds(Type type, AccessType accessType)
        {
            return GetIds(type, accessType, this.db).AsEnumerable();
        }
    }
}
