
using ErrorOr;
using FinApp.Application.Features.EmiCalculation.Dtos;
using FinApp.Domain.Entities;
using MediatR;

namespace FinApp.Application.Features.EmiCalculation.Commands;

public record EmiCalculationDetailCommand : EmiBaseCommand, IRequest<ErrorOr<List<EmiCalculationDetailResponseDto>>>;

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

        for(var i = 1; i <= loan.Installments; i++)
        {
            var emi = new Emi();
            
            emi = new () {
                Month = i,
                OpeningBalance = emi.GetOpeningBalance(),
                MonthlyInterest = emi.GetMonthlyInterest(),
                MonthlyPricipal = emi.GetMonthlyPrincipal(),
                ClosingBalance = emi.GetClosingBalance()
            };

            emiCalculationDetailList.Add(new EmiCalculationDetailResponseDto(
                emi.Month,
                emi.OpeningBalance,
                monthlyEmi,
                emi.MonthlyInterest,
                emi.GetMonthlyPrincipal(),
                emi.GetClosingBalance(),
                emi.GetRemainingTotalInterest()
            ));
        }

        return emiCalculationDetailList;
    }
}