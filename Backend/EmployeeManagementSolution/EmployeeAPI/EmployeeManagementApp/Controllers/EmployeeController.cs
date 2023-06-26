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

        private readonly IManageEmployee<Employee, EmployeeDTO> _service;
        private readonly IUpdateEmployee _updateService;

        public EmployeeController(IManageEmployee<Employee, EmployeeDTO> service , IUpdateEmployee updateService)

        {
            _service = service;
            _updateService= updateService;
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

        [HttpPut("Update Phone Number")]
        [ProducesResponseType(typeof(ActionResult<Employee>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> UpdatePhoneNo (UpdateDTO item)
        {
            Employee emp= await _updateService.UpdatePhoneNo(item);
            if(emp != null)
            {
                return Ok(emp);
            }
            return BadRequest("Unable to Update Phone number ");
        }

        [HttpPut("Update Address")]
        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> UpdateAddress(UpdateDTO item)
        {
            Employee emp = await _updateService.UpdateAddress(item);
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest("Unable to Update Address");
        }

        [HttpPut("Update Passport number")]
        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> UpdatePassportNo(UpdateDTO item)
        {
            Employee emp = await _updateService.UpdatPassportNo(item);
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest("Unable to Update Passport Number ");
        }


        [HttpPut("Update DL Number")]
        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> UpdateDLNumber(UpdateDTO item)
        {
            Employee emp = await _updateService.UpdateDLNumber(item);
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest("Unable to Update Driving Licence Number ");
        }



        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateStatus(ChangeStatusDTO changeStatusDTO)
        {
            try
            {
                var result = await _service.ChangeStatus(changeStatusDTO);
                if (result)
                {
                  return  Ok(result);
                }
               
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
           return  BadRequest("unable to update");
        }

    }
}
