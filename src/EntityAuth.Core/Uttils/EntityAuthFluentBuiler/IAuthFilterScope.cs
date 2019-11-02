using Microsoft.Extensions.DependencyInjection;

namespace EntityAuth.Core.Uttils
{
    public interface IAuthFilterScope
    {
        public IFilterImplementation SetAuthFilterScope(ServiceLifetime scope);
    }
}
