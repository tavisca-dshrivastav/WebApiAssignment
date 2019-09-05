namespace EmployeeManagementSystem.Models
{
    public class GeneralEmployee : Employee
    {
        private EmployeeData record;

        public GeneralEmployee(EmployeeData record)
        {
            this.record = record;
        }

        public override EmployeeData GetEmployeeData()
        {
            return record;
        }
    }
}