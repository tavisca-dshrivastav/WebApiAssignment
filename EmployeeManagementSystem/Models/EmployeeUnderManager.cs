using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeUnderManager
    {
        public EmployeeData ManagerInfo { get; set; }
        public string[] EmployeesIdUnderManager { get; set; }
    }
}
