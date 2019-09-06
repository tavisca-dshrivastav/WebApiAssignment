using System;
using Xunit;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Test
{
    public class EmployeeFixture
    {
        [Fact]
        public void Employee_can_be_manager()
        {
            EmployeeData employeeData = new EmployeeData(EmployeeType.MANAGER, "123", "deepak", 21, 12);
            Employee employee = new EmployeeFactory().MakeEmployee(employeeData);
            Assert.IsType<Manager>(employee);
        }
        [Fact]
        public void Employee_can_be_General_Employee()
        {
            EmployeeData employeeData = new EmployeeData(EmployeeType.MANAGER, "123", "deepak", 21, 12);
            Employee employee = new EmployeeFactory().MakeEmployee(employeeData);
            Assert.IsType<Manager>(employee);
        }
    }
}
