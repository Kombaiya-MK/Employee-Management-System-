using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Interfaces
{
    public interface IGenerateUserID
    {
        public Task<string> GenerateUserId(int count);
    }
}
