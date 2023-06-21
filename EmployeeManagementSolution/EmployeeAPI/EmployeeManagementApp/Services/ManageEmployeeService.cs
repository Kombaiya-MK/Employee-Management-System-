using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Services
{
    public class ManageEmployeeService : IManageEmployee<Employee, EmployeeDTO, String>
    {
        public Task<Employee> AddEmployee(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> GetEmployees(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeDetails(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeStatus(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
