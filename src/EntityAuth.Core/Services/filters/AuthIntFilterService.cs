using System;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <int> id entities
    /// todo
    /// </summary>
    public class AuthIntFilterService : BaseAuthFilterService<int>
    {
        public AuthIntFilterService(IAuthorizationService<int> authorizationService) : base(authorizationService)
        {
        }

        public override IEnumerable<int> GetIds(Type type)
        {
            return new List<int>() { 1, 2 };
        }
    }
}
