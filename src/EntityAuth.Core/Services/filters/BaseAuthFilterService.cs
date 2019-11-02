using System;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    public abstract class BaseAuthFilterService<T> : IAuthFilterService<T>
    {
        private readonly IAuthorizationService<T> _authorizationService;

        public BaseAuthFilterService(IAuthorizationService<T> authorizationService)
        {
            _authorizationService = authorizationService;

            if (_authorizationService == null)
                throw new Exception($"{nameof(IAuthorizationService<T>)} must be injected");
        }

        public virtual IEnumerable<T> GetIds(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
