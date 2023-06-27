using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagementApp.Services
{
    public class ManageEmployeeService : IManageEmployee
    {
        private readonly IRepo<User, string> _userRepo;
        private readonly IRepo<Employee, string> _empRepo;
        private readonly IGenerateToken _tokenService;
        private readonly IGenerateUserID _userIdService;

        public ManageEmployeeService(
            IRepo<Employee,string> empRepo,
            IRepo<User,string> userRepo,
            IGenerateToken tokenService,
            IGenerateUserID userIdService) 
        { 
            _userRepo=userRepo;
            _empRepo=empRepo;
            _tokenService=tokenService;
            _userIdService = userIdService;
 
        }
        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.Get(userDTO.EmpId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.EmpId = userData.EmpId;
                user.Status = userData.Status;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO> Register(EmployeeDTO employee)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            var allEmployees = await _empRepo.GetAll();
            employee.User.EmpId =await _userIdService.GenerateUserId(allEmployees.Count);
            employee.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(employee.PasswordClear ?? "1234"));
            employee.User.PasswordKey = hmac.Key;
            employee.Age= DateTime.Today.Year - new DateTime(employee.DateOfBirth.Year, employee.DateOfBirth.Month, employee.DateOfBirth.Day).Year;
            employee.User.Role = employee.User.Role ?? "Admin";
            var userResult = await _userRepo.Add(employee.User);
            var internResult = await _empRepo.Add(employee);
            if (userResult != null && internResult != null)
            {
                user = new UserDTO();
                user.EmpId = userResult.EmpId;
                user.Role = userResult.Role;
                user.Status = userResult.Status;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
        public async Task<ChangeStatusDTO> ChangeStatus(ChangeStatusDTO changeDTO)
        {
            var userData = await _userRepo.Get(changeDTO.EmpID);
            if(userData != null)
            {
                userData.Status = changeDTO.Status;
                var result = _userRepo.Update(userData);
                if(result != null)
                {
                    return changeDTO;
                }
            }
            return null;
        }

        public async Task<List<Employee>> GetAllIntern(ManagerIdDTO item)
        {
            var employees= await _empRepo.GetAll();
            if(employees != null)
            {
                var employeesByManager = employees.Where(s=>s.User.ManagerId == item.ManagerId);
                return employeesByManager.ToList();
            }
            return null;
        }

        public async Task<Employee> GetProfile(GetEmployeeDTO item)
        {
            Employee emp = new Employee();
            var getEmp= await _empRepo.Get(item.EmpID);
            var getUser = await _userRepo.Get(item.EmpID);
            if(getUser != null && getEmp != null)
            {
                emp.EmpId = getEmp.EmpId;
                emp.Name=getEmp.Name;
                emp.Email=getEmp.Email;
                emp.DateOfBirth= getEmp.DateOfBirth;
                emp.Age= getEmp.Age;
                emp.Gender= getEmp.Gender;
                emp.DLNumber= getEmp.DLNumber;
                emp.PassportNumber= getEmp.PassportNumber;
                emp.Address= getEmp.Address;
                emp.PassportNumber=getEmp.PassportNumber;
                emp.User = getUser;
                return emp;
            }
            return null;
        }
    }
}
