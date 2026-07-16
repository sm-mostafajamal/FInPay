namespace FinApp.Domain.Entities;

public class Loan
{
    public int Id { get; }
    public int UserId {get; set;}
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

    public ICollection<Emi> Emis { get; private set; } = new List<Emi>();

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
            6
        );
    }

    public decimal GetMonthlyInterestRate()
    {
        return Math.Round(InterestRate / 12m / 100m, 6);
    }


    //     private readonly List<Emi> _emis = new();

    // public IReadOnlyCollection<Emi> Emis => _emis.AsReadOnly();

    // public void AddEmi(Emi emi)
    // {
    //     _emis.Add(emi);
    // }
}