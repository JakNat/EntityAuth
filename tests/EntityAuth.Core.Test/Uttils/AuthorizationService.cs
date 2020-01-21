using EntityAuth.Core.Services;
using System;

namespace EntityAuth.Core.Test.Uttils
{
    /// <summary>
    /// dummy auth service
    /// need to discus how we authorize user
    /// </summary>
    public class AuthorizationService<T> : IAuthorizationService
    {
        private T userId;

        public AuthorizationService()
        {
            this.userId = default(T);
        }

        public T GetCurrentUserId()
        {
            return userId;
        }

        public string GetCurrentRole()
        {
            return "Administrator";
        }

        public void SetCurrentUser(T id)
        {
            userId = id;
        }
    }
}
