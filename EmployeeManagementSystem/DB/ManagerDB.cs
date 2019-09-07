using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.DB
{
    public class ManagerDB
    {
        public static List<Manager> managers = new List<Manager>
        {
            (Manager)EmployeeDataDB.employeeList[0],
            (Manager)EmployeeDataDB.employeeList[4]
        };
        public ManagerDB()
        {
            managers[0].EmployeesUnderManager = new List<Employee>
            {
                EmployeeDataDB.employeeList[1], EmployeeDataDB.employeeList[2], EmployeeDataDB.employeeList[3]
            };
            managers[1].EmployeesUnderManager = new List<Employee>
            {
                EmployeeDataDB.employeeList[5], EmployeeDataDB.employeeList[6]
            };
        }
    }
}
