namespace EmployeeManagementSystem.Models
{
    public class Manager : Employee
    {
        private EmployeeData record;

        public Manager(EmployeeData record)
        {
            this.record = record;
        }

        public override EmployeeData GetEmployeeData()
        {
            return record;
        }
    }
}