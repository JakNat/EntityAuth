using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityAuth.Core.Services
{
    /// <summary>
    /// dummy service for <long> id entities
    /// todo
    /// </summary>
    public class AuthLongFilterService : BaseAuthFilterService<long>
    {
        public AuthLongFilterService(IAuthorizationService<long> authorizationService/*, DbContext dbContext*/) : base(authorizationService/*, dbContext*/)
        {
        }
    }
}
