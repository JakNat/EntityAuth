using EntityAuth.Shared.Models;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    public interface IMemorizeService
    {
        void Add(Role role);
        void AddChildren(Role role, IEnumerable<Role> children);
        bool Contains(Role role);
        bool ContainsChildren(Role role);
        Role Get(Role role);
        IEnumerable<Role> GetChildren(Role role);
        void Clear();
    }
}