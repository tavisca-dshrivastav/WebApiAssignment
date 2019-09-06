using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem
{
    public static class EmployeeList
    {

        public static List<EmployeeData> employeeList = new List<EmployeeData>
            {
                new EmployeeData(EmployeeType.MANAGER, "123", "Deepak", 21, 12312),
                new EmployeeData(EmployeeType.GENERALEMPLOYEE, "124", "Vikram", 21, 12123),
                new EmployeeData(EmployeeType.GENERALEMPLOYEE, "125", "Prakhar", 21, 12233),
                new EmployeeData(EmployeeType.GENERALEMPLOYEE, "126", "Tushar", 21, 12433),
                new EmployeeData(EmployeeType.MANAGER, "127", "Aniket", 21, 12233),
                new EmployeeData(EmployeeType.GENERALEMPLOYEE, "128", "Rohit", 21, 12233),
                new EmployeeData(EmployeeType.GENERALEMPLOYEE, "129", "Rahul", 21, 12323)
            };

        public static Dictionary<EmployeeData, List<EmployeeData>> employeeUnderManager = new Dictionary<EmployeeData, List<EmployeeData>>{
            {
                employeeList[0],
                    new List<EmployeeData>{ employeeList[1], employeeList[2], employeeList[3] }
            },
            {   employeeList[4],
                    new List<EmployeeData>{ employeeList[5], employeeList[6] }
            }
        };

        public static bool updateEmployeeData(string id, EmployeeData record)
        {
            int recordIndex = employeeList.IndexOf(employeeList.Where<EmployeeData>(x => x.Id == id).FirstOrDefault<EmployeeData>());
            if (recordIndex < 0)
                return false;
            employeeList[recordIndex] = record;
            return true;
        }

        public static EmployeeData GetManager(string id)
        {
            var managers = GetManagersData();
            foreach (var manager in managers)
                if (manager.Id.Equals(id))
                    return manager;
            return null;
        }

        public static bool AssignEmployeesToManager(string managerId, string[] employeesId)
        {
            var manager = managerId.GetEmployeeData();
            if (manager is null || !(new EmployeeFactory().MakeEmployee(manager) is Manager))
                return false;
            var employeeList = GetEmployeeFromIds(employeesId);
            if (employeeList.Count <= 0)
                return false;
            employeeUnderManager[manager] = employeeList;

            return true;
        }

        private static List<EmployeeData> GetEmployeeFromIds(string[] employeesId)
        {
            List<EmployeeData> employees = new List<EmployeeData>();
            foreach (var empId in employeesId)
            {
                employees.Add(GetEmployeeData(empId));
            }
            return employees;
        }

        public static List<EmployeeData> GetEmployeesUnderManager(EmployeeData manager)
        {
            return employeeUnderManager[manager];
        }

        public static List<EmployeeData> GetManagersData()
        {
            var managerList = new List<EmployeeData>();
            foreach(var empRecord in employeeList)
            {
                var emp = new EmployeeFactory().MakeEmployee(empRecord);
                if (emp is Manager)
                    managerList.Add(empRecord);
            }
            return managerList;
        }

        public static Dictionary<Employee, List<Employee>> empUnderManagerList = new Dictionary<Employee, List<Employee>>
            {
                {
                    new EmployeeFactory().MakeEmployee(employeeList[0]),
                    new List<Employee>{ new EmployeeFactory().MakeEmployee(employeeList[1]), new EmployeeFactory().MakeEmployee(employeeList[2]), new EmployeeFactory().MakeEmployee(employeeList[3]) }
                },
                {
                    new EmployeeFactory().MakeEmployee(employeeList[4]),
                    new List<Employee>{ new EmployeeFactory().MakeEmployee(employeeList[5]), new EmployeeFactory().MakeEmployee(employeeList[6])}
                },
        };

        public static EmployeeData GetEmployeeData(this string id)
        {
            foreach (var emp in employeeList)
                if (emp.Id.Equals(id))
                    return emp;
            return null;
        }
        
        public static void AddEmployee(this EmployeeData employeeData)
        {
            employeeList.Add(employeeData);
        }
    }
}
