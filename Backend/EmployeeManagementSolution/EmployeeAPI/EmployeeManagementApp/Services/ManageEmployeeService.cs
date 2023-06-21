using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Services
{
    public class ManageEmployeeService : IManageEmployee<Employee, EmployeeDTO>
    {
        private readonly IMapper<Employee, EmployeeDTO> _mapper;
        private readonly IRepo<Employee, string> _repo;
        private readonly ILogger _logger;

        public ManageEmployeeService(IRepo<Employee , string> repo , IMapper<Employee ,EmployeeDTO> mapper,ILogger logger) 
        { 
            _mapper = mapper;
            _repo = repo;
            _logger= logger;
        }

        public async Task<Employee> AddEmployee(EmployeeDTO item)
        {
            Employee employee =new Employee();
            employee = await _mapper.MapEmployee(item);
            return await _repo.Add(employee);
        }

        public async Task<bool> ChangeStatus(ChangeStatusDTO changeStatusDTO)
        {
            try
            {
                var employee = await _repo.Get(changeStatusDTO.EmpId);

                if (employee != null)
                {
                    employee.Status = changeStatusDTO.Status;
                    await _repo.Update(employee);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Unable to change status");
            }
        }

        public Task<ICollection<Employee>> GetEmployees(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeDetails(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetEmployeeCount()
        {
            var count = _repo.GetAll().Result.Count.ToString();
            return count;
        }

    }
}
