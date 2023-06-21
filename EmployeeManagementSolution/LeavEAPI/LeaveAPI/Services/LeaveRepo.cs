using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveAPI.Services
{
    public class LeaveRepo : IRepo<String, Leave>
    {
        private Context _context;
        private readonly ILogger<LeaveRepo> _logger;

        public LeaveRepo(Context contex, ILogger<LeaveRepo> logger) { 
        _context= contex;
        _logger= logger;
        }
        public async Task<Leave?> Add(Leave item)
        {
            try
            {
                _context.Leaves.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return null;

        }

        public async Task<ICollection<Leave>?> GetAll()
        {
            try
            {
                ICollection<Leave> leaves = await _context.Leaves.ToListAsync();
                return leaves;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }

            return null;
        }

        public async Task<Leave?> Update(Leave item)
        {
            try
            {
                var leaveData = await Get(item.EmpId);
                if (leaveData != null)
                {

                    await _context.SaveChangesAsync();
                    return leaveData;

                }
            }
            catch(Exception ex)
            { 
                _logger.LogError(ex.Message);
            }
            return null;
            

        }
        public async Task<Leave?> Get(String key)
        {
            try
            {
                var leave = await _context.Leaves.FirstOrDefaultAsync(u => u.EmpId == key);
                return leave;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return null;
        }
    }
}
