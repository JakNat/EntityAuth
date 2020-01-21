using AspectInjector.Broker;
using System;
using EntityAuth.Shared.Models;

namespace EntityAuth.Core.Aspects
{
    /// <summary>
    /// Generating ACL tables:
    /// <para> (<see cref="ResourceType{T}"/>, <see cref="Role"/>, <see cref="Permission{T}"/>) </para>
    /// <para> Attribute for DbContext.OnModelCreating method </para>
    /// <para> Needed migration </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [Injection(typeof(AclTablesAspect))]
    public class AclTablesAttribute : Attribute
    {
        public AclTablesAttribute(Type identyfierType)
        {
            IdentyfierType = identyfierType;
        }

        public Type IdentyfierType { get; }
    }
}
