namespace FinApp.Application.Features.EmiCalculation.Commands;

public record EmiBaseCommand
{
    public required string Lender {get; init;}
    public required int Installments {get; init;}
    public required decimal PrincipalAmount {get; init;}
    public required decimal InterestRate {get; init;}
}
