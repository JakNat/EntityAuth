using System;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    public interface IAuthFilterService
    {
        IEnumerable<int> GetAclIds(Type type);
    }
}