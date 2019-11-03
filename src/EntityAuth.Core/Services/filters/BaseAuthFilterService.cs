using EntityAuth.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Services
{
    public abstract class BaseAuthFilterService<T> : IAuthFilterService<T>
    {
        protected readonly IAuthorizationService<T> _authorizationService;

        public BaseAuthFilterService(IAuthorizationService<T> authorizationService)
        {
            _authorizationService = authorizationService;

            if (_authorizationService == null)
                throw new Exception($"{nameof(IAuthorizationService<T>)} must be injected");
        }

        public virtual IEnumerable<T> GetIds(Type type, DbContext dbContext)
        {
            var role = _authorizationService.GetCurrentRole();

            var permissions = dbContext.Set<Permission<T>>();

            var resourceIds = permissions
                 .Where(x =>
                 x.Role.Name == role && x.ResourceType.Name == type.Name)
                 .Select(x => x.ResourceId);

            return resourceIds;
        }
    }
}
