﻿using CsvHelper.Configuration;
using Employees.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(p => p.Id).Index(0);
            Map(p => p.Name).Index(1);
            Map(p => p.Surename).Index(2);
            Map(p => p.Email).Index(3);
            Map(p => p.Phone).Index(4);
        }
    }
}
