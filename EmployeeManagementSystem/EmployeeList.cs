using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem
{
    public class EmployeeList
    {
        
        public static List<Employee> employeeList = new List<Employee>
            {
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.MANAGER, "123", "Deepak", 21, 12312)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "124", "Vikram", 21, 12123)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "125", "Prakhar", 21, 12233)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "126", "Tushar", 21, 12433)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.MANAGER, "127", "Aniket", 21, 12233)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "128", "Rohit", 21, 12233)),
                new EmployeeFactory().MakeEmployee(new EmployeeData(EmployeeType.GENERALEMPLOYEE, "129", "Rahul", 21, 12323))
            };
        public static Dictionary<Employee, List<Employee>> empUnderManagerList = new Dictionary<Employee, List<Employee>>
            {
                { employeeList[0], new List<Employee>{ employeeList[1], employeeList[2], employeeList[3] } },
                { employeeList[4], new List<Employee>{ employeeList[5], employeeList[6] } },
            };
        
    }
}
