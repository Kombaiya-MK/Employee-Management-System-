using Microsoft.EntityFrameworkCore;

namespace LeaveAPI.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Leave> Leaves { get; set; }

      
    }
}
