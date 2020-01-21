using EntityAuth.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Shared.Models
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
        [ForeignKey("ResourceType")]
        public int ResourceTypeId { get; set; }

        public ResourceType ResourceType { get; set; }

        public T ResourceId { get; set; }

        public AccessType AccessType{ get; set; }
    }
}
