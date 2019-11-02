using AspectInjector.Broker;
using Microsoft.EntityFrameworkCore;
using System;
using Z.EntityFramework.Plus;
using System.Linq;
using EntityAuth.Core.Services;
using System.Collections.Generic;
using System.Reflection;

namespace EntityAuth.Core
{
    [Aspect(Scope.PerInstance, Factory = typeof(AuthorizationAspectFactory))]
    public class AuthorizationAspect
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthorizationAspect(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Advice(Kind.After, Targets = Target.Constructor)]
        public void SetFilters(
            [Argument(Source.Instance)] object instance,
            [Argument(Source.Type)] Type classType,
            [Argument(Source.Triggers)] Attribute[] attributes)
        {
            if (_serviceProvider == null)
                return;

            var context = instance as DbContext
                ?? throw new ArgumentException($"{instance} is not DbContext");

            var authAttribute = attributes.First() as AuthorizationAttribute;

            var identifierType = authAttribute.IdentifierType;

            //Get all dbset<> with AuthFilter attribute
            var dbSets = GetPropertiesWithAttribute(classType, typeof(AuthFilterAttribute));

            context.SetFilters(identifierType, _serviceProvider, dbSets);
        }

        private IEnumerable<PropertyInfo> GetPropertiesWithAttribute(Type classType, Type attributeType)
        {
            return classType.GetProperties()
                .Where(prop => Attribute.IsDefined(prop, attributeType));
        }
    }
}
