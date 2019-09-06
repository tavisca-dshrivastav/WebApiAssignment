using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models.Contracts;
namespace EmployeeManagementSystem.Models
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee MakeEmployee(EmployeeData record)
        {
            if (record.Type == EmployeeType.GENERALEMPLOYEE)
                return new GeneralEmployee();
            else if(record.Type == EmployeeType.MANAGER)
                return new Manager();
            throw new InvalidEmployeeTypeException("This is invalid Exception");
        }
    }
}
