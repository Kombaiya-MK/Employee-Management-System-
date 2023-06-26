using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using LeaveAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCORS")]

    public class LeaveController : ControllerBase
    {
        private readonly ILeaveManage _leaveManage;

        public LeaveController(ILeaveManage leaveManage)
        {
            _leaveManage = leaveManage;
        }

        [HttpPost("AddLeave")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<ActionResult<Leave>> AddLeaveDetails(Leave leave)
        {
            var leaveData = await _leaveManage.AddLeave(leave);
            if (leaveData != null)
            {
                return Created("Leave", leaveData);
            }
            return BadRequest(new Error(2, "Leave Details not added "));

        }
        [HttpPut("UpdateLeaveStatus")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<IActionResult> UpdateLeaveStatus(UpdateDTO updateDTO)
        {

            Leave? leaveData = await _leaveManage.ApproveStatus(updateDTO);
            if (leaveData != null)
            {
                return Accepted("Updated Leave status successfully");
            }
            return BadRequest(new Error(2, "Cannot Update Leave Status"));



        }
        [HttpGet("GetAllLeaves")]
        [ProducesResponseType(typeof(ICollection<Leave>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<ActionResult<Leave>> GetAllUsers()
        {

            ICollection<Leave?> leaves = await _leaveManage.GetAllUsers();
            if (leaves != null)
            {
                return Ok(leaves);
            }
            return NotFound(new Error(1, "There are no leave details currently in table"));
        }
    }
}
