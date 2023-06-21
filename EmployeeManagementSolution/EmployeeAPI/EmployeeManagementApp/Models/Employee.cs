using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementApp.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Employee ID Required")]
        [MaxLength(10)]
        public string? EmpId { get; set; }

        [Required(ErrorMessage = "Employee Name Required")]
        public string? Name { get; set; }

       
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Employee Age Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Employee Gender Required")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Employee Phone number Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers allowed for phone number.")]
        public string? PhoneNumber { get; set; }

        [Required, MinLength(1)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }

        [Required(ErrorMessage = "Employee Status Required")]
        public string? Status { get; set; }
        [Required(ErrorMessage = "Manager ID Required")]
        public string? ManagerId { get; set; }
        [Required(ErrorMessage = "Passport Number Required")]
        public string? PassportNumber { get; set; }
        [Required(ErrorMessage = "Driving License Number Required")]
        public string? DLNumber { get; set; }
    }
}
