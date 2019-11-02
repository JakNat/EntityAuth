using EntityAuth.Core.Services;
using System;

namespace EntityAuth.Core.Uttils
{
    public interface IAuthorizationImplementation
    {
        /// <summary>
        /// Set Authorization Service implementation
        /// <para>TImplementation must implements <see cref="IAuthorizationService{}>"/> 
        /// where T is Resource identifier</para>
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public IInject SetAuthorizationImplementationType<TImplementation>();

        /// <summary>
        /// Set Authorization Service implementation
        /// <para>ImplementationType must implements <see cref="IAuthorizationService{}>"/> 
        /// where T is Resource identifier</para>
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public IInject SetAuthorizationImplementationType(Type ImplementationType);
    }
}
