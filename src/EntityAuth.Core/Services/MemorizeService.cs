using EntityAuth.Shared.Models;
using System.Collections;
using System.Collections.Generic;

namespace EntityAuth.Core.Services
{
    public class MemorizeService : IMemorizeService
    {
        private Hashtable prevResults;
        private Hashtable prevChildrenResults;

        public MemorizeService()
        {
            prevResults = new Hashtable();
            prevChildrenResults = new Hashtable();
        }

        public bool Contains(Role role)
            => role != null ? 
            prevResults.Contains(role.Name) : false;
        
        public bool ContainsChildren(Role role)
            => role != null ?
            prevChildrenResults.Contains(role.Name) : false;
        

        public void Add(Role role)
        {
            if(role != null)
                prevResults.Add(role.Name, role);
        }

        public void AddChildren(Role role, IEnumerable<Role> children)
        {
            prevChildrenResults.Add(role.Name, children);
        }

        public Role Get(Role role)
        {
            return prevResults[role.Name] as Role;
        }

        public IEnumerable<Role> GetChildren(Role role)
        {
            return prevChildrenResults[role.Name] as List<Role>;
        }

        public void Clear()
        {
            prevResults.Clear();
            prevChildrenResults.Clear();
        }
    }
}
