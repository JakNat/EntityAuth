using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy auth service
    /// need to discus how we authorize user
    /// </summary>
    public class AuthorizationService<T> : IAuthorizationService<T>
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

    public class DummyIntAuthorizationService : AuthorizationService<int>
    {

    }

    public class DummyLongAuthorizationService : AuthorizationService<long>
    {

    }

    public class DummyGuidAuthorizationService : AuthorizationService<Guid>
    {

    }
}
