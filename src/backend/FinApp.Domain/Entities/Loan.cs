public class Loan
{
    public int Id {get; set;}
    public int UserId {get; set;}
    public string? UserName {get; set;} = string.Empty;
    public string? Lender {get; set;} = string.Empty;
    public int Installments {get; set;}
    public decimal InterestRate {get; set;}
    public decimal PrincipalAmount {get; set;}
    public decimal TotalInterest {get; set;}
    public int Status {get; set;}
    public DateTime StartedAt {get; set;}
    public DateTime ClosedAt {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}

    public Loan() {}

    public decimal GetTotalInterest()
    {
        return (GetMonthlyEmi() * Installments) - PrincipalAmount;
    }

    public decimal GetMonthlyEmi()
    {
        decimal monthlyRate = GetMonthlyInterestRate();
        decimal factor = (decimal)Math.Pow((double)(1 + monthlyRate), Installments);

        return Math.Round(
            PrincipalAmount * monthlyRate * factor / (factor - 1),
            2
        );
    }

    public decimal GetMonthlyInterestRate()
    {
        return InterestRate / 12m / 100m;
    }
}