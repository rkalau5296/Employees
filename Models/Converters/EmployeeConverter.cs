using Employees.Models.Domains;
using Employees.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Models.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                Name = model.Name,
                Surename = model.Surename,
                Email = model.Email,
                Phone = model.Phone,
            };
        }

        public static Employee ToDao(this EmployeeWrapper wrapper)
        {
            return new Employee
            {
                Id = wrapper.Id,
                Name = wrapper.Name,
                Surename = wrapper.Surename,
                Email = wrapper.Email,
                Phone = wrapper.Phone,
            };
        }
    }
}
