using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service
    /// todo
    /// </summary>
    public class AuthFilterService : IAuthFilterService
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthFilterService(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;

            if (_authorizationService == null)
                throw new Exception($"{nameof(IAuthorizationService)} must be injected");
        }

        public IEnumerable<int> GetAclIds(Type type)
        {
            var userID = _authorizationService.GetCurrentUserId();
            // todo 
            // get entities which user have access to

            var aclIds = new List<int>() { 1, 2 };

            return aclIds;
                
        }
    }
}
