namespace FinApp.Domain.Entities;

public class Emi
{
    public int Id { get; }
    public int LoanId { get; set; }
    public int Month { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal MonthlyInterest { get; set; }
    public decimal MonthlyPricipal { get; set; }
    public decimal ClosingBalance { get; set; }
    public decimal Status { get; set; }
    public decimal PaidAt { get; set; }
    
    public Loan Loan { get; set; } = null!;


    public Emi() {}

    public decimal GetOpeningBalance()
    {
        return Month == 1 ? Loan.PrincipalAmount : GetClosingBalance();
    }

    public decimal GetClosingBalance()
    {
        return Loan.PrincipalAmount - GetMonthlyPrincipal();
    }
    public decimal GetMonthlyInterest()
    {
        return Loan.PrincipalAmount * Loan.GetMonthlyInterestRate();
    }
    public decimal GetMonthlyPrincipal()
    {
        return Loan.GetMonthlyEmi() - GetMonthlyInterest();
    }
    
    public decimal GetRemainingTotalInterest()
    {
        return Loan.GetTotalInterest() - GetMonthlyInterest();
    }
}