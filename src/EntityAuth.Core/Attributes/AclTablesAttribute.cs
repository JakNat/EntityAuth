using AspectInjector.Broker;
using System;
using EntityAuth.Shared.Models;

namespace EntityAuth.Core.Aspects
{
    /// <summary>
    /// Generating acl tables:
    /// <para> (<see cref="ResourceType{T}"/>, <see cref="Role"/>, <see cref="Permission{T}"/>) </para>
    /// <para> Attribute for DbContext.OnModelCreating method </para>
    /// <para> Needed migration </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [Injection(typeof(AclTablesAspect))]
    public class AclTablesAttribute : Attribute
    {
    }
}
