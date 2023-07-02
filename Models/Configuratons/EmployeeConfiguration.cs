using Employees.Models.Domains;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
namespace Employees.Models.Configuratons
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("dbo.Employees");
            HasIndex(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.None);
        }
    }
}
