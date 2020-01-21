using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class RoleForCreationDto
    {
        public string ParentRoleName { get; set; }


        [Required(ErrorMessage = "NewRoleName is required")]
        [StringLength(100, ErrorMessage = "NewRoleName cannot be loner then 100 characters")]
        public string NewRoleName { get; set; }
    }
}
