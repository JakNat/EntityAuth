using EntityAuth.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <long> id entities
    /// todo
    /// </summary>
    public class AuthGuidFilterService : BaseAuthFilterService<Guid>
    {
        public AuthGuidFilterService(IAuthorizationService<Guid> authorizationService/*, DbContext dbContext*/) : base(authorizationService/*, dbContext*/)
        {
        }
    }
}
