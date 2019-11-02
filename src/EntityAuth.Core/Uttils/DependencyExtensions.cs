using Microsoft.Extensions.DependencyInjection;

namespace EntityAuth.Core.Uttils
{
    public static class DependencyExtensions
    {
        public static IIdentifierSetter AddEntityFilter(this IServiceCollection services)
        {
            return new EntityAuthBuilder(services);
        }
    }
}