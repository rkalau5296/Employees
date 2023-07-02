using Employees.Models.Domains;
using Employees.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Employees.Models.Converters;
using System.Collections.ObjectModel;

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
        public EmployeeWrapper GetEmployee(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Employees.Single(x => x.Id == id).ToWrapper();                    
            }
        }
        public void AddToDb(List<Employee> employees)
        {
            using (var context = new ApplicationDbContext())
            {
                
                employees.ForEach(e =>
                {
                    context.Employees.Add(e);
                    context.SaveChanges();
                });                
            }
        }
        public void Update(EmployeeWrapper employee)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeeToUpdate = context.Employees.Single(x => x.Id == employee.Id);

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
