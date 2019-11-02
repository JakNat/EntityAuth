using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Core.Models
{
    [Table("EA_Permissions")]
    public class Permission<T>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        
        public Role Role { get; set; }

        [Required]
        [ForeignKey("Resource")]
        public T ResourceId { get; set; }

        public Resource<T> Resource { get; set; }
    }
}
