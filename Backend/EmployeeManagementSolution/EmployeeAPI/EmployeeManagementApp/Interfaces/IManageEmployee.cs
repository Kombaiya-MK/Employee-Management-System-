using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Interfaces
{

    public interface IManageEmployee
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> Register(EmployeeDTO employee);
        public Task<ChangeStatusDTO> ChangeStatus(ChangeStatusDTO changeDTO);
        public Task<List<Employee>> GetAllIntern(ManagerIdDTO item);
       
    }
}
