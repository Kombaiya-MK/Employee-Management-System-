using LeaveAPI.Models;
using LeaveAPI.Models.DTO;

namespace LeaveAPI.Interfaces
{
    public interface ILeaveManage
    {
        public Task<Leave?> AddLeave(Leave item);
        public Task<Leave?> ApproveStatus(UpdateDTO updateDTO);
        public Task<ICollection<Leave?>> GetAllUsers();
    }
}
