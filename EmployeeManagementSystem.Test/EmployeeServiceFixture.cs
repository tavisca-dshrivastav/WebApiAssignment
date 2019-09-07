using Xunit;
using EmployeeManagementSystem.Models;
using FluentAssertions;
namespace EmployeeManagementSystem.Test
{
    public class EmployeeServiceFixture
    {
        EmployeeData employeeData;
        [Fact]
        public void Employee_data_should_have_id_name_age_salary_type()
        {
            employeeData = new EmployeeData(EmployeeType.GENERALEMPLOYEE, "130", "Deepak", 21, 2321);
            employeeData.Should().BeOfType<EmployeeData>();
        }
    }
}
