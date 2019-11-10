using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAuth.Shared.Models
{
    /// <summary>
    /// <seealso cref="https://stackoverflow.com/questions/5875646/database-schema-for-acl"/>
    /// </summary>
    [Table("EA_Resource")]
    public class ResourceType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
