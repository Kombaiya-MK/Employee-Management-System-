using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models.DTO
{
    public class EmployeeDTO: Employee
    {
        public string? PasswordClear { get; set; }
    }
}
