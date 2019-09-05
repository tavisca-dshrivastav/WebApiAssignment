using System;
using Xunit;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Test
{
    public class EmployeeFixture
    {
        [Fact]
        public void Employee_is_manager_when_type_is_manager()
        {
            EmployeeData employeeData = new EmployeeData(EmployeeType.GENERALEMPLOYEE, "123", "deepak", 21, 12);
            Employee employee = new EmployeeFactory().MakeEmployee(employeeData);
            Assert.IsType<GeneralEmployee>(employee);
        }
    }
}
