using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using LeaveAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveManage _leaveManage;

        public LeaveController(ILeaveManage leaveManage) {
            _leaveManage = leaveManage;
                }
        
        [HttpPost("AddLeave")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<ActionResult<Leave>> AddProduct( Leave leave)
        {
            var leaveData = await _leaveManage.AddLeave(leave);
            if (leaveData != null)
            {
                return Created("Leave", leaveData);
            }
            return BadRequest(new Error(2, "Product Details not added "));

        }
        [HttpPut("UpdateLeaveStatus")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<IActionResult> UpdateLeaveStatus( UpdateDTO updateDTO)
        {
        
            Leave leaveData = await _leaveManage.ApproveStatus(updateDTO);
            if (leaveData != null)
            {
                return Accepted("Updated Leave status successfully");
            }
            return BadRequest(new Error(2, "Cannot Update Leave Status"));
        }
    }
}
