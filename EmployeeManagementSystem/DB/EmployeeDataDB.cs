using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.DB
{
    public static class EmployeeDataDB
    {
        public static List<Employee> employeeList = new List<Employee>
            {
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.MANAGER, "123", "Deepak", 21, 12312)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "124", "Vikram", 21, 12123)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "125", "Prakhar", 21, 12233)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "126", "Tushar", 21, 12433)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.MANAGER, "127", "Aniket", 21, 12233)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "128", "Rohit", 21, 12233)),
                EmployeeFactory.CreateEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "129", "Rahul", 21, 12323))
            };
        
    }
}
