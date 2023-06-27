using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
    public class User
    {
        [Key]
        public string? EmpId { get; set; }
        public string? ManagerId { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
    }
}
