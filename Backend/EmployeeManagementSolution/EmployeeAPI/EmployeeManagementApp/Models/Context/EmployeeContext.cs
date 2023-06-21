using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Models.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
