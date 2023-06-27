using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Interfaces
{
    public interface IUpdateEmployee
    {
        public Task<Employee> UpdatePhoneNo(UpdateDTO item);
        public Task<Employee> UpdateAddress(UpdateDTO item);
        public Task<Employee> UpdatPassportNo(UpdateDTO item);
        public Task<Employee> UpdateDLNumber(UpdateDTO item);

    }
}
