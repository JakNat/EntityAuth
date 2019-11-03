using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Core.Models
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

    }
}
