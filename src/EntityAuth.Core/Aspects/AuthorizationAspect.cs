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
        private readonly IAuthFilterService _authFilterService;

        public AuthorizationAspect(IAuthFilterService authFilterService)
        {
            _authFilterService = authFilterService;
        }

        [Advice(Kind.After, Targets = Target.Constructor)]
        public void SetFilters(
            [Argument(Source.Instance)] object instance,
            [Argument(Source.Type)] Type classType)
        {
            if (_authFilterService == null)
                return;

            var context = instance as DbContext
                ?? throw new ArgumentException($"{instance} is not DbContext");

            //Get all dbset<> with AuthFilter attribute
            var dbSets = GetPropertiesWithAttribute(classType, typeof(AuthFilterAttribute));

            foreach (var dbSet in dbSets)
            {
                var type = dbSet.PropertyType.GenericTypeArguments[0];
                
                var aclIds = _authFilterService.GetAclIds(type);
             
                context.SetFilter(type, aclIds);
            }
        }

        private IEnumerable<PropertyInfo> GetPropertiesWithAttribute(Type classType, Type attributeType)
        {
            return classType
                .GetProperties()
                .Where(prop => Attribute.IsDefined(prop, attributeType));
        }
    }
}
