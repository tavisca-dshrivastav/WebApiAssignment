namespace EmployeeManagementSystem.Models
{
    

    public class EmployeeData
    {
        public EmployeeData(EmployeeType type, string id, string name, int age, double salary)
        {
            Type = type;
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
        }
        

        public EmployeeType Type { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }

    }
}