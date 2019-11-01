using System;
using EntityAuth.Core.Services;

namespace EntityAuth.Core
{
    public static class AuthorizationAspectFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static object GetInstance(Type type)
        {
            if (type != typeof(AuthorizationAspect))
                throw new ArgumentException($"{nameof(AuthorizationAspectFactory)} can create instances only of type {nameof(AuthorizationAspect)}");

            var service = ServiceProvider?.GetService(typeof(IAuthFilterService)) as IAuthFilterService;

            return new AuthorizationAspect(service);
        }
    }
}
