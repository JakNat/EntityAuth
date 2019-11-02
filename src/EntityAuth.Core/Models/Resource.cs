using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityAuth.Core.Models
{
    [Table("EA_Resource")]
    public class Resource<T>
    {
        [Required]
        public T Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
