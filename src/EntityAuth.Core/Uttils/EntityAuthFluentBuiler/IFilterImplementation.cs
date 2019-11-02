using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityAuth.Core.Uttils
{
    public interface IFilterImplementation
    {
        public IAuthorizationScope SetAuthFilterImplementationType<TImplementation>();
        public IAuthorizationScope SetAuthFilterImplementationType(Type implementationType);
        public IAuthorizationImplementation SetAuthorizationScope(ServiceLifetime scope);
    }
}
