using System.Linq;
using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Services
{
    public class EmployeeRepository : IRepo<Employee, string>
    {
        private readonly EmployeeContext _context;
        private readonly ILogger _logger;

        public EmployeeRepository(EmployeeContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Employee?> Add(Employee item)
        {
            try
            {
                _context.Employee.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ;
            }
            throw new Exception("unable to add");
        }

        public async Task<Employee?> Delete(string key)
        {
            try
            {
                var employee = await Get(key);
                if (employee != null)
                {
                    _context.Employee.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            throw new Exception("no employee found");


        }

        public async Task<Employee?> Get(string key)
        {
            try
            {
                var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmpId == key);
                if (employee != null)
                {
                    return employee;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            throw new Exception("no employee found");
        }

        public Task<ICollection<Employee?>> GetAll()
        {
            try
            {
                var employees = _context.Employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            throw new Exception("no employees found");
        }

        public async Task<Employee?> Update(Employee item)
        {
            try
            {
                if (item.EmpId != null)
                {
                    var employee = await Get(item.EmpId);
                    if (employee != null)
                    {
                        employee.Status = item.Status;
                        employee.DLNumber = item.DLNumber;
                        employee.PassportNumber = item.PassportNumber;
                        employee.Address = item.Address;
                        _context.Employee.Add(item);
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            throw new Exception("unable to update");
        }
    }
}
