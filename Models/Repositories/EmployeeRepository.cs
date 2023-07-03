using Employees.Models.Domains;
using Employees.Models.Wrappers;
using System.Collections.Generic;
using System.Linq;
using Employees.Models.Converters;

namespace Employees.Models.Repositories
{
    public class EmployeeRepository
    {
        public List<EmployeeWrapper> GetEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();

                return employees.Select(x => x.ToWrapper()).ToList();
            }
        }
        
        public void AddToDb(List<Employee> employees)
        {
            using (var context = new ApplicationDbContext())
            {                   
                employees.ForEach(e =>
                {                    
                    if (!context.Employees.Any(x => x.Id == e.Id))
                    {
                        context.Employees.Add(e);
                        context.SaveChanges();
                    }                    
                });                
            }
        }
        public void Update(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();

            using (var context = new ApplicationDbContext())
            {
                var employeeToUpdate = context.Employees.Find(employee.Id);

                employeeToUpdate.Id = employee.Id;
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Surename = employee.Surename;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.Phone = employee.Phone;
                context.SaveChanges();
            }
        }
        
    }
}
