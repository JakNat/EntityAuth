using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    public interface IAuthFilterService<T> 
    {
        IEnumerable<T> GetIds(Type type, DbContext dbContext);
    }
}