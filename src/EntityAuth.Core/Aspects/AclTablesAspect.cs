using AspectInjector.Broker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityAuth.Core.Aspects
{
    [Aspect(Scope.PerInstance)]
    public class AclTablesAspect
    {
        [Advice(Kind.After, Targets = Target.Method)]
        public void SetTables(
            [Argument(Source.Arguments)] object[] args,
            [Argument(Source.Triggers)] Attribute[] attributes)
        {
            var aclAttribute = attributes
                .Single(x => x.GetType().Equals(typeof(AclTablesAttribute)))
                as AclTablesAttribute;

            var idType = aclAttribute.Type;
            
            var modelBuilder = args[0] as ModelBuilder;


            if (idType.Equals(typeof(int)))
            {
                modelBuilder.SetAclTables<int>();
            }
            else if (idType.Equals(typeof(long)))
            {
                modelBuilder.SetAclTables<long>();
            }
            else if (idType.Equals(typeof(Guid)))
            {
                modelBuilder.SetAclTables<Guid>();
            }
            else
            {
                throw new Exception("Identifier Type is not supported. " +
                    "Supported types : {int, long, GUid}");
            }
        }
    }
}
