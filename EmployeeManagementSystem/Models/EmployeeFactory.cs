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
                return new GeneralEmployee(record);
            else if(record.Type == EmployeeType.MANAGER)
                return new Manager(record);
            throw new InvalidEmployeeTypeException("This is invalid Exception");
        }
        public static Employee CreateEmployee(EmployeeData record)
        {
            return new EmployeeFactory().MakeEmployee(record);
        }
    }
}
