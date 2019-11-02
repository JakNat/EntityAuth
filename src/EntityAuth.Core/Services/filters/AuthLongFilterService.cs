using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <long> id entities
    /// todo
    /// </summary>
    public class AuthLongFilterService : BaseAuthFilterService<long>
    {
        public AuthLongFilterService(IAuthorizationService<long> authorizationService) : base(authorizationService)
        {
        }

        public override IEnumerable<long> GetIds(Type type)
        {
            return new List<long>() { 1, 2 };
        }
    }    
}
