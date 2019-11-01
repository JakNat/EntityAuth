using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy auth service
    /// need to discus how we authorize user
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        private int userId;

        public AuthorizationService(int userId)
        {
            this.userId = userId;
        }

        public int GetCurrentUserId()
        {
            return userId;
        }

        public void SetCurrentUser(int id)
        {

            userId = id;
        }
    }
}
