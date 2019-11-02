using AspectInjector.Broker;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAuth.Core.Aspects
{
    /// <summary>
    /// Generating acl tables:
    /// <para> (EA_Resources, EA_Roles, EA_Permissions) </para>
    /// <para> Attribute for DbContext.OnModelCreating method </para>
    /// <para> Needed migration </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [Injection(typeof(AclTablesAspect))]
    public class AclTablesAttribute : Attribute
    {
        public Type Type { get; set; }
        public AclTablesAttribute(Type type)
        {
            Type = type;
        }
    }
}
