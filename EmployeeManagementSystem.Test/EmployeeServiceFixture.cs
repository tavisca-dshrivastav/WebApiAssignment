using Xunit;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.Models;
using FluentAssertions;
using EmployeeManagementSystem.DB;
using System.Linq;
namespace EmployeeManagementSystem.Test
{
    public class EmployeeServiceFixture
    {
        EmployeeService service = new EmployeeService();
        [Fact]
        public void Employee_service_should_get_employee()
        {
            service.GetAllEmployee().Count.Should().Be(EmployeeDataDB.employeeList.Count);
        }
        [Fact]
        public void Employee_service_should_add_employee()
        {
            EmployeeData employeeData = new EmployeeData(EmployeeType.GENERALEMPLOYEE, "133", "AniketSingla", 21, 12433);
            service.AddEmployee(EmployeeFactory.CreateEmployee(employeeData));
            EmployeeDataDB.employeeList.Where<Employee>(x => x.Record.Equals(employeeData)).ToList<Employee>().Count.Should().Be(1);
        }
        [Fact]
        public void Employee_service_should_update_employee()
        {

        }
        [Fact]
        public void Employee_service_should_delete_employee()
        {

        }
            [Fact]
        public void Employee_service_should_get_employee_by_id()
        {

        }
    }
}
