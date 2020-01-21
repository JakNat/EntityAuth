using AspectInjector.Broker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityAuth.Core.Aspects
{
    [Aspect(Scope.PerInstance)]
    public class AclTablesAspect
    {
        [Advice(Kind.After, Targets = Target.Method)]
        public void SetTables(
            [Argument(Source.Arguments)] object[] args,
            [Argument(Source.Triggers)] Attribute[] attributes,
            [Argument(Source.Type)] Type instanceType)
        {
            //System.Diagnostics.Debugger.Launch();
            var aclAtr = attributes
                .Single(x => x.GetType() == typeof(AclTablesAttribute))
                as AclTablesAttribute;

            IEnumerable<Type> resourcesType = 
                GetPropertiesWithAuthFilterAttribute(instanceType);

            var modelBuilder = args[0] as ModelBuilder;

            new EntityAuthTablesBuilder()
                 .SetModelBuilder(modelBuilder)
                 .SetResouces(resourcesType)
                 .SetResourceIdentifierType(aclAtr.IdentyfierType)
                 .Build();
        }

        private static IEnumerable<Type> GetPropertiesWithAuthFilterAttribute(Type instanceType)
        {
            return instanceType.GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(AuthFilterAttribute)))
                .Select(x => x.PropertyType.GenericTypeArguments[0]);
        }
    }
}
