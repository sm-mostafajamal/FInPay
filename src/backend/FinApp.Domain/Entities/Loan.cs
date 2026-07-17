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

    public IList<Emi> Emis { get; private set; } = new List<Emi>();

    public Loan() {}

    public decimal GetTotalInterest()
    {
        return (GetMonthlyEmi() * Installments) - PrincipalAmount;
    }

    public decimal GetMonthlyEmi()
    {
        decimal monthlyRate = GetMonthlyInterestRate();
        decimal factor = (decimal)Math.Pow((double)(1 + monthlyRate), Installments);

        return Math.Round(PrincipalAmount * monthlyRate * factor / (factor - 1), 4);
    }

    public decimal GetMonthlyInterestRate()
    {
        return InterestRate / 12m / 100m;
    }

    public void AddEmi(Emi emi)
    {
        Emis.Add(emi);
    }

    public IList<Emi> GenerateEmiSchedule()
    {
        var balance = PrincipalAmount;
        var interestRate = GetMonthlyInterestRate();
        var monthlyEmi = GetMonthlyEmi();

        for(var month = 1; month <= Installments; month++)
        {
            var openingBalance = balance;
            var monthlyInterest = Math.Round(balance * interestRate, 4);
            var monthlyPrincipal = 0m;
            var closingBalance = 0m;

            if(month == Installments)
            {
                monthlyPrincipal = closingBalance;
                closingBalance = 0m;
            }
            else
            {
                monthlyPrincipal = monthlyEmi - monthlyInterest;
                closingBalance = balance - monthlyPrincipal;
            } 
            
            AddEmi(new Emi(
                month,
                openingBalance,
                monthlyInterest,
                monthlyPrincipal,
                closingBalance
            ));

            balance = closingBalance;
        }

        return Emis;

    }

}