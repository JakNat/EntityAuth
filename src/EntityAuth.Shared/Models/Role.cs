using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Shared.Models
{
    [Table("EA_Roles")]
    public class Role
    {
        public Role()
        {
        }

        public Role(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private readonly ILazyLoader _lazyLoader;

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        private Role parent;

        public Role Parent
        {
            get => _lazyLoader.Load(this, ref parent);
            set => parent = value;
        }


        public  List<Role> Children { get; set; }

        public IEnumerable<Role> GetOffsprings()
        {
            var offsprings = new List<Role>();
            if (Children == null)
                return offsprings;

            foreach (var role in Children)
            {
                offsprings.Add(role);
                offsprings.AddRange(role.GetOffsprings());
            }
            return offsprings;
        }
    }
}
