using EntityAuth.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityAuth.Core.Uttils
{
    public class RoleComposite
    {
        public RoleComposite(Role role)
        {
            Name = role.Name;
            SetChildren(role);
        }

        public string Name { get; set; }
        public List<RoleComposite> Children { get; set; }

        public void SetChildren(Role role)
        {
            Children = role.Children?.Select(x => new RoleComposite(x)).ToList();
        }
    }
}
