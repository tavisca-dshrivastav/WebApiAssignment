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
        public async Task<Employee> GetEmployee(string id)
        {
            return await Task.Run(()=> EmployeeDataDB.employeeList.Where<Employee>(x => x.Record.Id == id).ToList<Employee>().FirstOrDefault<Employee>());
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await Task.Run(() => EmployeeDataDB.employeeList);
        }
        public async Task AddEmployee(Employee employee)
        {
            await Task.Run(()=> EmployeeDataDB.employeeList.Add(employee));
        }
        public async Task UpdateEmployee(string id, Employee employee)
        {
            await Task.Run(()=> 
                        EmployeeDataDB.employeeList[EmployeeDataDB.employeeList.IndexOf(GetEmployee(id).Result)] =
                        employee);
        }
        public async Task DeleteEmployee(string id)
        {
            await Task.Run(()=>EmployeeDataDB.employeeList.RemoveAt(EmployeeDataDB.employeeList.IndexOf(GetEmployee(id).Result)));
        }

        public async Task<List<Employee>> GetEmployeesFromIds(string[] employeeIds)
        {
          return  await Task.Run(() =>{
               var employeeList = new List<Employee>();
               foreach (var empId in employeeIds){
                   var emp = GetEmployee(empId).Result;
                   employeeList.Add(emp);
               }
               return employeeList;
           });
        }
    }
}
