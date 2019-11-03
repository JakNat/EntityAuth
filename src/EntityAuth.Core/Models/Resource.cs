using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityAuth.Core.Models
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
