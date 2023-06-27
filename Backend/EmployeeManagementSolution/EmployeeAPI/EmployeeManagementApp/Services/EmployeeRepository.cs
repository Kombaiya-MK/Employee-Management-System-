﻿using System.Diagnostics;
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
   
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee?> Add(Employee item)
        {
            try
            {
                _context.Employees.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("no employee found");
        }

        public async Task<Employee?> Get(string key)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == key);
                if (employee != null)
                {
                    return employee;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("no employee found");
        }

        public async Task<ICollection<Employee?>> GetAll()
        {
            try
            {
                var employees =await _context.Employees.ToListAsync();
                if (employees != null)
                    return employees;
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                        employee.DLNumber = item.DLNumber;
                        employee.PassportNumber = item.PassportNumber;
                        employee.Address = item.Address;
                        await _context.SaveChangesAsync();
                        return employee;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("unable to update");
        }
    }
}
