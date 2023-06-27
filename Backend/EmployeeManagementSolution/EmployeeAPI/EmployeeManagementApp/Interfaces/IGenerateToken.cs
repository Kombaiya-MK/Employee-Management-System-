using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);
    }
}
