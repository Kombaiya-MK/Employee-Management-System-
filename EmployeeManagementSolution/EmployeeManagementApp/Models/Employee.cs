using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementApp.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Roll { get; set; }
        public string? Status { get; set; }
        public string? ManagerId { get; set; }
        public string? PassportNumber { get; set; }
        public string? DLNumber { get; set; }
    }
}
