using AspectInjector.Broker;
using EntityAuth.Core.Models;
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
            var modelBuilder = args[0] as ModelBuilder;

            var aclAttribute = attributes
                .Single(x => x.GetType().Equals(typeof(AclTablesAttribute)))
                as AclTablesAttribute;

            var idType = aclAttribute.Type;

            var resourcesType = instanceType.GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(AuthFilterAttribute)))
                .Select(x => x.PropertyType.GenericTypeArguments[0]);

            // todo
            var dummyRoles = new List<Role>()
            {
                new Role()
                {
                   Id = 1,
                   Name = "Administrator"
                },
                new Role()
                {
                   Id = 2,
                   Name = "User"
                }
            };

            var aclBuilder = modelBuilder.SetAclTablesBuilder()
                
                // todo implment reflection for SetResourceIdentifierType and remove unneceasery code
                //.SetResourceIdentifierType(idType)
                .SetResouces(resourcesType)
                .SetRoles(dummyRoles);
                
                // todo
                //.Build();

            // todo remove if reflection was added
            if (idType.Equals(typeof(int)))
            {
                aclBuilder.Build<int>();
            }
            else if (idType.Equals(typeof(long)))
            {
                aclBuilder.Build<long>();
            }
            else if (idType.Equals(typeof(Guid)))
            {
                aclBuilder.Build<Guid>();
            }
            else
            {
                throw new Exception("Identifier Type is not supported. " +
                    "Supported types : {int, long, GUid}");
            }
        }
    }
}
