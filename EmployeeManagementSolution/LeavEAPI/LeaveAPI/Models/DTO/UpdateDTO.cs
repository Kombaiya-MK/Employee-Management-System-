using System.ComponentModel.DataAnnotations;

namespace LeaveAPI.Models.DTO
{
    public class UpdateDTO
    {
        [Required(ErrorMessage = "Employee Id cannot be empty")]
        public string? EmpId { get; set; }
        [Required(ErrorMessage = "LeaveStatus cannot be empty")]
        public string? LeaveStatus { get; set; }
    }
}
