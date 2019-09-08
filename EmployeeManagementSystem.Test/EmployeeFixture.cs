using Xunit;
using FluentAssertions;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Test
{
    public class EmployeeFixture
    {
        EmployeeFactory factory = new EmployeeFactory();
        [Fact]
        public void Employee_factory_can_create_manager()
        {
           var employeeData = new EmployeeData(EmployeeType.MANAGER, "130", "Deepak", 21, 2321);
           factory.MakeEmployee(employeeData).Should().BeOfType<Manager>();
        }

        [Fact]
        public void Employee_factory_can_create_GeneralEmployee()
        {
            var employeeData = new EmployeeData(EmployeeType.GENERALEMPLOYEE, "130", "Deepak", 21, 2321);
            factory.MakeEmployee(employeeData).Should().BeOfType<GeneralEmployee>();
        }
    }
}
