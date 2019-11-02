using AspectInjector.Broker;
using System;

namespace EntityAuth.Core
{
    /// <summary>
    /// Attribute for marking DbContext class where we want to have Auth filters
    /// </summary>
    [Injection(typeof(AuthorizationAspect))]
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizationAttribute : Attribute
    {
        public AuthorizationAttribute(Type identifierType)
        {
            IdentifierType = identifierType;
        }

        public Type IdentifierType { get; set; }
    }
}
