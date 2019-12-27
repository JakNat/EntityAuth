using EntityAuth.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Uttils
{
    public static class ServiceProviderExtensions
    {
        public static IEntityAuthConfiguration GetEntityAuthConfiguration(this IServiceProvider provider)
        {
            return provider.GetService(typeof(IEntityAuthConfiguration)) as EntityAuthConfiguration;
        }
    }
}
