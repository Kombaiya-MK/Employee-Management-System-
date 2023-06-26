using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using LeaveAPI.Models.DTO;

namespace LeaveAPI.Services
{
    public class LeaveService : ILeaveManage
    {
        private IRepo<string, Leave> _repo;

        public LeaveService(IRepo<string, Leave> repo) {
            _repo = repo;
        }
        public async Task<Leave?> AddLeave(Leave item)
        {
            item.LeaveStatus = "disapproved";
            Leave leaves = await _repo.Add(item);
            return leaves;
        }

        public async Task<Leave?> ApproveStatus(UpdateDTO updateDTO)
        {
            Leave leaveData= await _repo.Get(updateDTO.EmpId);
            leaveData.LeaveStatus = updateDTO.LeaveStatus;

            Leave leaves = await _repo.Update(leaveData);
            if(leaves != null )
            {
                return leaves;
            }
            return null;
        }

        public async Task<ICollection<Leave?>> GetAllUsers(GetAllDTO getAllDTO)
        {
            ICollection<Leave> leaves= await _repo.GetAll();
            leaves=leaves.Where(u=>u.ManagerId== getAllDTO.ManagerId).ToList();
            if (leaves != null )
            {
                return leaves;
            }
            return null;
        }
    }
}
