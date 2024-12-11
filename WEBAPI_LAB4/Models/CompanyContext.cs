using Microsoft.EntityFrameworkCore;

namespace WEBAPI_LAB4.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
