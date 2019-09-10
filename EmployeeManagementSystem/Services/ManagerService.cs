using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.DB;
using EmployeeManagementSystem.Services.Contract;

namespace EmployeeManagementSystem.Services
{
    public class ManagerService: IManagerService
    {
        EmployeeService employeeService = new EmployeeService();
        private static ManagerDB mb = new ManagerDB();

        public Manager GetManager(string id)
        {
            var emp = employeeService.GetEmployee(id);
            bool isManager = emp is Manager;
            return isManager ? (Manager)emp : null;
        }

        public List<Manager> GetAllManager()
        {
            return employeeService.GetAllEmployee().Where<Employee>(x => x is Manager).Cast<Manager>().ToList<Manager>();
        }
        
        public void AddManager(Manager manager, string[] employeeIds)
        {
            employeeService.AddEmployee(manager);
            var employees = employeeService.GetEmployeesFromIds(employeeIds);
            MakeManager(manager.Record.Id, employees);
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
