
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
        
        var monthlyEmi = loan.GetMonthlyEmi();
        var totalInterest = loan.GetTotalInterest();
        var emiList = loan.GenerateEmiSchedule();

        List<EmiCalculationDetailResponseDto> emiCalculationDetails = new ();
        foreach(var emi in emiList)
        {
            totalInterest = totalInterest - emi.MonthlyInterest;

            emiCalculationDetails.Add(
                new EmiCalculationDetailResponseDto(
                    emi.Month,
                    emi.OpeningBalance,
                    monthlyEmi,
                    emi.MonthlyInterest,
                    emi.MonthlyPrincipal,
                    emi.ClosingBalance,
                    // After Approving loan
                    totalInterest,
                    emi.ClosingBalance + totalInterest
                ));
        }

        return emiCalculationDetails;
    }
}