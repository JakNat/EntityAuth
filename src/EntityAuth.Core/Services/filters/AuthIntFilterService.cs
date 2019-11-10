using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <int> id entities
    /// todo
    /// </summary>
    public class AuthIntFilterService : BaseAuthFilterService<int>
    {
        public AuthIntFilterService(IAuthorizationService<int> authorizationService/*, DbContext dbContext*/) : base(authorizationService/*, dbContext*/)
        {
        }
    }
}
