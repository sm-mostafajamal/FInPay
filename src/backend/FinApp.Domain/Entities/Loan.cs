public class Loan
{
    public int Id {get; set;}
    public int UserId {get; set;}
    public string? UserName {get; set;} = string.Empty;
    public string? Lender {get; set;} = string.Empty;
    public int TenorMonths {get; set;}
    public double InterestRate {get; set;}
    public decimal PrincipleAmount {get; set;}
    public decimal TotalInterest {get; set;}
    public int Status {get; set;}
    public DateTime StartedAt {get; set;}
    public DateTime ClosedAt {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}

}