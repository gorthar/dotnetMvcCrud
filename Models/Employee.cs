namespace interview.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsWorking { get; set; }
        public decimal HaurlyWage { get; set; }
        public List<EmployeePayments> Payments { get; set; }

    }
}
