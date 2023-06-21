using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Services;

namespace EmployeeManagementApp.Mapper
{
    public class Mapper : IMapper<Employee, EmployeeDTO>
    {
        private readonly ManageEmployeeService _service;

        public Mapper(ManageEmployeeService service)
        {
            _service = service;
        }
        public async Task<Employee> MapEmployee(EmployeeDTO item)
        {
            Employee employee = new Employee();
            employee.EmpId = "EMP" +  _service.GetEmployeeCount();
            employee.Name = item.Name;
            employee.DateOfBirth = item.DateOfBirth;
            employee.DLNumber = item.DLNumber;
            employee.PhoneNumber = item.PhoneNumber;
            employee.Email = item.Email;
            employee.Address = item.Address;
            employee.PassportNumber = item.PassportNumber;
            employee.Age = DateTime.Today.Year - new DateTime(item.DateOfBirth.Year,item.DateOfBirth.Month,item.DateOfBirth.Day).Year;
            employee.ManagerId = item.ManagerId;
            employee.Role = item.Role;
            employee.Gender = item.Gender;
            employee.Status = "INACTIVE";
            return employee;
        }
    }
}
