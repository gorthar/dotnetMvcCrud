using interview.Models;
using Microsoft.EntityFrameworkCore;

namespace interview.DB
{
    public class appDbContext: DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet <EmployeePayments> EmployeesPayments { get; set;}
        
    }
}
