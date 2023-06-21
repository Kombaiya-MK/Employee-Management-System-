using System.ComponentModel.DataAnnotations;

namespace LeaveAPI.Models
{
    public class Leave { 


        [Key]
        public int  LeaveId { get; set; }
        public string? LeaveType { get; set; }
        [Required(ErrorMessage = "Employee Id cannot be empty")]
        public string? EmpId { get; set; }
        public string? ManagerId { get; set;}
        [MinLength(10, ErrorMessage = "Reason should be Detailed")]
        public string? Reason { get; set;}
        [Required(ErrorMessage ="Start date should be given")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "End date should be given")]

        public DateTime? EndDate { get; set;}
        public string? LeaveStatus { get; set; } 


    }
}
