using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.DB;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        public Employee GetEmployee(string id)
        {
            return EmployeeDataDB.employeeList.Where<Employee>(x => x.Record.Id == id).FirstOrDefault<Employee>();
        }
        public List<Employee> GetAllEmployee()
        {
            return EmployeeDataDB.employeeList;
        }
        public void AddEmployee(EmployeeData record)
        {
            EmployeeDataDB.employeeList.Add(new EmployeeFactory().MakeEmployee(record));
        }
        public void UpdateEmployee(string id, EmployeeData record)
        {
            EmployeeDataDB.employeeList[EmployeeDataDB.employeeList.IndexOf(GetEmployee(id))]
                =new EmployeeFactory().MakeEmployee(record);
        }
        public void DeleteEmployee(string id)
        {
            EmployeeDataDB.employeeList.RemoveAt(EmployeeDataDB.employeeList.IndexOf(GetEmployee(id)));
        }

        public List<Employee> GetEmployeesFromIds(string[] employeeIds)
        {
            var employeeList = new List<Employee>();
            foreach(var empId in employeeIds)
            {
                var emp = GetEmployee(empId);
                employeeList.Add(emp);
            }
            return employeeList;
        }
    }
}
