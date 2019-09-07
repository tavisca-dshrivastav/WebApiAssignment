using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.DB;

namespace EmployeeManagementSystem.Services
{
    public class ManagerService
    {
        EmployeeService employeeService = new EmployeeService();

        ManagerDB mb = new ManagerDB();
        public Employee GetManager(string id)
        {
            var emp = employeeService.GetEmployee(id);
            bool isManager = emp is Manager;
            return isManager ? emp : null;
        }
        
        public List<Employee> GetAllManager()
        {
            return employeeService.GetAllEmployee().Where<Employee>(x=>x is Manager).ToList<Employee>();
        }

        public void AddManager(EmployeeData managerData, string[] employeeIds)
        {
            employeeService.AddEmployee(managerData);
            var employees = employeeService.GetEmployeesFromIds(employeeIds);
            MakeManager(managerData.Id, employees);
        }

        public void MakeManager(string managerId, List<Employee> employeeDatas)
        {
            var emp = (Manager)employeeService.GetEmployee(managerId);
            emp.EmployeesUnderManager = employeeDatas;
        }

        public List<Employee> GetEmployeeUnderManager(string id)
        {
            var emp = (Manager)employeeService.GetEmployee(id);
            return emp.EmployeesUnderManager;
        }
    }
}
