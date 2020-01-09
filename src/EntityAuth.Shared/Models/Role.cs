using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Shared.Models
{
    /// <summary>
    /// <seealso cref="https://stackoverflow.com/questions/5875646/database-schema-for-acl"/>
    /// </summary>
    [Table("EA_Roles")]
    public class Role
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public int ParentId { get; set; }

        public  virtual Role Parent { get; set; }
        public  List<Role> Children { get; set; }

    }

    //public class RoleNode 
    //{
    //    public int Id { get; set; }

    //    public int AncestorId { get; set; }
    //    public virtual Role Ancestor { get; set; }

    //    public int OffspringId { get; set; }
    //    public virtual Role Offspring { get; set; }

    //    public int Separation { get; set; }
    //}

}
