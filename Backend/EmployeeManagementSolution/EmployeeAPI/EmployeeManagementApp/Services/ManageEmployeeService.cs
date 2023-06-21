using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;

namespace EmployeeManagementApp.Services
{
    public class ManageEmployeeService : IManageEmployee<Employee, EmployeeDTO,ManagerIdDTO>
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

<<<<<<< HEAD
        public async Task<ICollection<Employee>> GetAllEmployees(ManagerIdDTO item)
=======
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
>>>>>>> 2370cd7fd354a340397ff66160b8f2854b5b13cd
        {
            var employees = await _repo.GetAll();
            if(employees != null)
            {
                var selectedEmp= employees.Where(s=>s.ManagerId== item.ManagerId).ToList();
                if(selectedEmp != null)
                    return selectedEmp;
                return null;
            }
            return null;
        }

        public Task<Employee> UpdateEmployeeDetails(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Task<Employee> UpdateEmployeeStatus(EmployeeDTO item)
        {
            throw new NotImplementedException();
        }
=======
        public async Task<string> GetEmployeeCount()
        {
            var count = _repo.GetAll().Result.Count.ToString();
            return count;
        }

>>>>>>> 2370cd7fd354a340397ff66160b8f2854b5b13cd
    }
}
