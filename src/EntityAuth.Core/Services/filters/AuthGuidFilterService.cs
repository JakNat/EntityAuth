using System;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <long> id entities
    /// todo
    /// </summary>
    public class AuthGuidFilterService : BaseAuthFilterService<Guid>
    {
        public AuthGuidFilterService(IAuthorizationService<Guid> authorizationService) : base(authorizationService)
        {
        }

        public override IEnumerable<Guid> GetIds(Type type)
        {
            return new List<Guid>() { Guid.NewGuid()};
        }
    }
}
