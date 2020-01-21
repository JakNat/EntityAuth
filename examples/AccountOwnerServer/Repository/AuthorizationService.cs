using EntityAuth.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ServerAuthorizationService : IAuthorizationService
    {
        public string Role { get; set; }

        public ServerAuthorizationService()
        {
        }

        public string GetCurrentRole()
        {
            return Role ?? "Admin";
        }
    }
}
