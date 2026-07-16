namespace FinApp.Application.Features.EmiCalculation.Commands;

using MediatR;
using ErrorOr;
using FinApp.Application.Features.EmiCalculation.Dtos;
using FinApp.Domain.Entities;

public record CalculateEmiCommand : EmiBaseCommand, IRequest<ErrorOr<CalculateEmiResponseDto>>;

public class CalculateEmiHandler : IRequestHandler<CalculateEmiCommand, ErrorOr<CalculateEmiResponseDto>>
{
    public async Task<ErrorOr<CalculateEmiResponseDto>> Handle(CalculateEmiCommand command, CancellationToken cancellationToken)
    {
        var loan = new Loan ()
        {
            Lender = command.Lender,
            Installments = command.Installments,
            InterestRate = command.InterestRate,
            PrincipalAmount = command.PrincipalAmount,
        };
        
        return new CalculateEmiResponseDto(
            loan.Installments, 
            $"{loan.InterestRate} %", 
            loan.GetMonthlyEmi(), 
            loan.PrincipalAmount, 
            loan.GetTotalInterest()
        );

    }
}