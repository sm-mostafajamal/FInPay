
using ErrorOr;
using FinApp.Application.Features.EmiCalculation.Dtos;
using FinApp.Domain.Entities;
using MediatR;

namespace FinApp.Application.Features.EmiCalculation.Commands;

// public record EmiCalculationDetailCommand : EmiBaseCommand, IRequest<ErrorOr<List<EmiCalculationDetailResponseDto>>>;
public record EmiCalculationDetailCommand(
    string Lender,
    int Installments,
    decimal PrincipalAmount,
    decimal InterestRate
) : IRequest<ErrorOr<List<EmiCalculationDetailResponseDto>>>;

public class EmiCalculationDetailCommandHandler : IRequestHandler<EmiCalculationDetailCommand, ErrorOr<List<EmiCalculationDetailResponseDto>>>
{
    public async Task<ErrorOr<List<EmiCalculationDetailResponseDto>>> Handle(EmiCalculationDetailCommand command, CancellationToken cancellationToken)
    {
        var loan = new Loan ()
        {
            Lender = command.Lender,
            Installments = command.Installments,
            InterestRate = command.InterestRate,
            PrincipalAmount = command.PrincipalAmount,
        };
        
        List<EmiCalculationDetailResponseDto> emiCalculationDetailList = new();
        var monthlyEmi = loan.GetMonthlyEmi();
        var emi = new Emi();
        emi.Loan = loan;

        for(var i = 1; i <= loan.Installments; i++)
        {
          
            emi.Month = i;
            emi.OpeningBalance = emi.GetOpeningBalance();
            emi.MonthlyInterest = emi.GetMonthlyInterest();
            emi.MonthlyPricipal = emi.GetMonthlyPrincipal();
            emi.ClosingBalance = emi.GetClosingBalance();
Console.WriteLine($"{emi.Month}, {emi.OpeningBalance}, {monthlyEmi}, {emi.MonthlyInterest},{emi.MonthlyPricipal}, {emi.ClosingBalance},");

            emiCalculationDetailList.Add(new EmiCalculationDetailResponseDto(
                emi.Month,
                emi.OpeningBalance,
                monthlyEmi,
                emi.MonthlyInterest,
                emi.MonthlyPricipal,
                emi.ClosingBalance
                // emiT.GetRemainingTotalInterest()
            ));
        }
        return emiCalculationDetailList;
    }
}