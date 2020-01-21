using EntityAuth.Shared.Models;
using System.Linq;

namespace EntityAuth.Core.Test.Services
{
    public static class RoleTestExtensions
    {
        public static Role WithChildren(this Role role, params Role[] children)
        {
            role.Children = children.ToList();
            return role;
        }
    }
}
