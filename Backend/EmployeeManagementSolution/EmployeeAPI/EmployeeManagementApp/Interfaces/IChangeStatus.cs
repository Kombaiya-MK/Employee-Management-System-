using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Interfaces
{
    public interface IChangeStatus
    {
        public Task<bool> ChangeStatus(ChangeStatusDTO changeStatusDTO);
    }
}
