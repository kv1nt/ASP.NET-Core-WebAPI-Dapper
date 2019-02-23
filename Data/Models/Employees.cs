namespace Data.Models
{
    public class Employees
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Post { get; set; }
        public string Salary { get; set; }
        public string PriorSalary { get; set; }

        public EmployeesInfo EmployeesInfo { get; set; }
        public Orders Orders{ get; set; }
    }
}