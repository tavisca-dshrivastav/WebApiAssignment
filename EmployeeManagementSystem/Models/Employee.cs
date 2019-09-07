﻿using EmployeeManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagementSystem.Models
{
    public abstract class Employee
    {
        public EmployeeData Record { get; private set; }
        public Employee(EmployeeData record)
        {
            Record = record;
        }
    }
}
