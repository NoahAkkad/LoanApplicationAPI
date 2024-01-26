public class LoanApplication
{
    public int Id { get; set; }
    public Borrower Borrower { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
}
