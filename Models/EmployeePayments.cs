namespace interview.Models
{
    public class EmployeePayments
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public Employee Employee { get; set; }

    }
}
