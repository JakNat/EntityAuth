using System;

namespace EntityAuth.Core
{
    /// <summary>
    /// Adding Filter to DbSet<T>
    /// NOTE: T must implement <see cref="IPrimaryAuth"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AuthFilterAttribute : Attribute
    {

    }
}
