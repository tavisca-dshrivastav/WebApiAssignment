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
        public async Task<Employee> GetManager(string id)
        {
           return await Task.Run(()=>
            {
                var emp = employeeService.GetEmployee(id).Result;
                bool isManager = emp is Manager;
                return isManager ? emp : null;
            });
        }

        public async Task<List<Employee>> GetAllManager()
        {
            return await Task.Run(() => employeeService.GetAllEmployee().Result.Where<Employee>(x => x is Manager).ToList<Employee>());
        }
        
        public async Task AddManager(Manager manager, string[] employeeIds)
        {
            await Task.Run(() =>
            {
                employeeService.AddEmployee(manager).RunSynchronously();
                var employees = employeeService.GetEmployeesFromIds(employeeIds);
                MakeManager(manager.Record.Id, employees.Result).RunSynchronously();
            });
        }

        public async Task MakeManager(string managerId, List<Employee> employeeDatas)
        {
            await Task.Run(() =>
            {
                var emp = (Manager)employeeService.GetEmployee(managerId).Result;
                emp.EmployeesUnderManager = employeeDatas;
            });
        }

        public async Task<List<Employee>> GetEmployeeUnderManager(string id)
        {
            return await Task.Run(() => { 
                var emp = (Manager)employeeService.GetEmployee(id).Result;
                return emp.EmployeesUnderManager;
            });
        }
    }
}
