using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public class Manager : Employee
    {

        public List<Employee> EmployeesUnderManager { get; set; }
        public Manager(EmployeeData record) : base(record)
        {
           
        }
    }
}