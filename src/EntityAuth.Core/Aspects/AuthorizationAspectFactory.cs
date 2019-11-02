using System;

namespace EntityAuth.Core
{
    public static class AuthorizationAspectFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static object GetInstance(Type type)
        {
            if (type != typeof(AuthorizationAspect))
                throw new ArgumentException($"{nameof(AuthorizationAspectFactory)} can create instances only of type {nameof(AuthorizationAspect)}");


            return new AuthorizationAspect(ServiceProvider);
        }
    }
}
