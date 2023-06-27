using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeeManagementApp.Services
{
    public class UserRepository:IRepo<User,string>
    {
        private readonly EmployeeContext _context;

        public UserRepository(EmployeeContext context) 
        {
            _context=context;
        }

        public async Task<User> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("unable to add");
        }

        public async Task<User> Delete(string key)
        {
            try
            {
                var user = await Get(key);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("no employee found");
        }

        public async Task<User> Get(string key)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.EmpId == key);
                if (user != null)
                {
                    return user;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("no employee found");
        }

        public async Task<ICollection<User>> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                    return users;
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            throw new Exception("no employees found");
        }

        public async Task<User> Update(User item)
        {
            try
            {
                if (item.EmpId != null)
                {
                    var user =await Get(item.EmpId);
                    if (user != null)
                    {
                        user.Status = item.Status;
                        await _context.SaveChangesAsync();
                        return user;
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
