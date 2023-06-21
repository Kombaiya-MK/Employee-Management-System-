using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeManagementApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IManageEmployee<Employee, EmployeeDTO,ManagerIdDTO> _service;

        public EmployeeController(IManageEmployee<Employee, EmployeeDTO, ManagerIdDTO> service)
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

        [HttpGet("Get Employees by manager Id")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Employee>>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Employee>>> GetEmployees(ManagerIdDTO item)
        {
            var employees = await _service.GetAllEmployees(item);
            if(employees != null)
            {
                return Ok(employees);
            }
            return BadRequest("Unable to get Employees details");
        }
    }
}
