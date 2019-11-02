using Microsoft.Extensions.DependencyInjection;

namespace EntityAuth.Core.Uttils
{
    public interface IAuthorizationScope
    {
        public IAuthorizationImplementation SetAuthorizationScope(ServiceLifetime scope);
    }
}
