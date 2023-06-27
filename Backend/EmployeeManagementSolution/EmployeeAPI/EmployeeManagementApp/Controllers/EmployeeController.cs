using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;

namespace EmployeeManagementApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors(PolicyName = "MyCors")]
    public class EmployeeController : ControllerBase
    {

        private readonly IManageEmployee _service;
        private readonly IUpdateEmployee _updateService;

        public EmployeeController(IManageEmployee  service , IUpdateEmployee updateService)
        {
            _service = service;
            _updateService= updateService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(EmployeeDTO employee)
        {
            var result = await _service.Register(employee);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            var result = await _service.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Login ... Please Check Login Credentials ..");
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

        [HttpPut("Update Status")]
        [ProducesResponseType(typeof(ActionResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ChangeStatusDTO>> UpdateStatus(ChangeStatusDTO changeStatusDTO)
        {
            try
            {
                var result = await _service.ChangeStatus(changeStatusDTO);
                if (result!= null)
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
        [HttpPost("Get Employees By Manager ID")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Employee>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Employee>>> GetEmployees(ManagerIdDTO item)
        {
            try
            {
                var result = await _service.GetAllIntern(item);
                if(result != null)
                {
                    return Ok(result);
                }

            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest("Unable to get Employees");
        }
    }
}
