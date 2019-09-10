using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services.Contract
{
    interface IManagerService
    {
        Manager GetManager(string id);

        List<Manager> GetAllManager();
        
        void MakeManager(string managerId, List<Employee> employeeDatas);
        List<Employee> GetEmployeeUnderManager(string id);
        void AddManager(Manager manager, string[] employeeIds);


    }
}
