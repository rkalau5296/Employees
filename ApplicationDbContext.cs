using Employees.Models.Configuratons;
using Employees.Models.Domains;
using System.Data.Entity;

namespace Employees
{
    public class ApplicationDbContext : DbContext
    {   public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }
    }    
}