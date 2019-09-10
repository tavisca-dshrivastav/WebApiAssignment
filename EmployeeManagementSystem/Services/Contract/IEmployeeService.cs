using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.DB;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Services.Contract
{
    public interface IEmployeeService
    {
        Employee GetEmployee(string id);
        List<Employee> GetAllEmployee();
        void AddEmployee(Employee employee);
        void UpdateEmployee(string id, Employee employee);
        void DeleteEmployee(string id);
        List<Employee> GetEmployeesFromIds(string[] employeeIds);
        
    }
}
