using System;

namespace EntityAuth.Core
{
    /// <summary>
    /// Marking resources with filter
    /// <para> For DbContext.DbSet </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AuthFilterAttribute : Attribute
    {
    }
}
