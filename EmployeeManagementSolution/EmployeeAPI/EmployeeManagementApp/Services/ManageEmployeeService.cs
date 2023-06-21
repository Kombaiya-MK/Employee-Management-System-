using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Services
{
    public class ManageEmployeeService : IManageEmployee<Employee, EmployeeDTO>
    {
        private readonly IMapper<Employee, EmployeeDTO> _mapper;
        private readonly IRepo<Employee, string> _repo;

        public ManageEmployeeService(IRepo<Employee , string> repo , IMapper<Employee ,EmployeeDTO> mapper) 
        { 
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Employee> AddEmployee(EmployeeDTO item)
        {
            Employee employee =new Employee();
            employee = await _mapper.MapEmployee(item);
            return await _repo.Add(employee);
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

        public async Task<string> GetEmployeeCount()
        {
            var count =  _repo.GetAll().Result.Count.ToString();
            return count;
        }
    }
}
