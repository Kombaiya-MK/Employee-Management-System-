using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IManageEmployee<Employee, EmployeeDTO> _service;

        public EmployeeController(IManageEmployee<Employee, EmployeeDTO> service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<Employee>),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeDTO employee)
        {
            Employee emp = await _service.AddEmployee(employee);
            if(emp != null)
            {
                return Created("Employee Data Added Successfully!!!",emp);
            }
            return BadRequest("Operation failed");
        }
    }
}
