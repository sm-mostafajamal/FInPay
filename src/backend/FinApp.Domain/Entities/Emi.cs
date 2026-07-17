namespace FinApp.Domain.Entities;

public class Emi
{
    public int Id { get; }
    public int LoanId { get; set; }
    public int Month { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal MonthlyInterest { get; set; }
    public decimal MonthlyPrincipal { get; set; }
    public decimal ClosingBalance { get; set; }
    public decimal Status { get; set; }
    public decimal PaidAt { get; set; }
    
    public Loan Loan { get; set; } = null!;


    public Emi() {}

    public Emi(
        int month, 
        decimal openingBalance,
        decimal monthlyInterest, 
        decimal monthlyPrincipal, 
        decimal closingBalance 
    )
    {
        Month = month;
        OpeningBalance = openingBalance;
        MonthlyInterest = monthlyInterest;
        MonthlyPrincipal = monthlyPrincipal;
        ClosingBalance = closingBalance;
    }
}