using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Services
{
    public class UpdateEmployeeService :IUpdateEmployee
    {
        private readonly IRepo<Employee, string> _repo;
        public UpdateEmployeeService(IRepo<Employee, string> repo)
        {
            _repo = repo;
        }
        public async Task<Employee> UpdateAddress(UpdateDTO item)
        {
            var emp = await _repo.Get(item.EmpID);
            if (emp != null)
            {
                emp.Address = item.UpdateData;
                var result = await _repo.Update(emp);
                if (result != null)
                    return result;
            }
            return null;

        }

        public async Task<Employee> UpdateDLNumber(UpdateDTO item)
        {
            var emp = await _repo.Get(item.EmpID);
            if (emp != null)
            {
                emp.DLNumber = item.UpdateData;
                var result = await _repo.Update(emp);
                if (result != null)
                    return result;
            }
            return null;
        }

        public async Task<Employee> UpdatePhoneNo(UpdateDTO item)
        {
            var emp = await _repo.Get(item.EmpID);
            if (emp != null)
            {
                emp.PhoneNumber = item.UpdateData;
                var result = await _repo.Update(emp);
                if (result != null)
                    return result;
            }
            return null;
        }

        public async Task<Employee> UpdatPassportNo(UpdateDTO item)
        {
            var emp = await _repo.Get(item.EmpID);
            if (emp != null)
            {
                emp.PassportNumber = item.UpdateData;
                var result = await _repo.Update(emp);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
