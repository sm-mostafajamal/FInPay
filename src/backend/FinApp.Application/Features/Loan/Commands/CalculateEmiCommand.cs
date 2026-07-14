using MediatR;
using ErrorOr;
using FinApp.Application.Features.Loan.Dtos;

public record CalculateEmiCommand(
    string Lender,
    int Installments,
    decimal PrincipalAmount,
    decimal InterestRate
) : IRequest<ErrorOr<CalculateEmiResponseDto>>;

public class CalculateEmiHandler : IRequestHandler<CalculateEmiCommand, ErrorOr<CalculateEmiResponseDto>>
{
    public async Task<ErrorOr<CalculateEmiResponseDto>> Handle(CalculateEmiCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan ()
        {
            Lender = request.Lender,
            Installments = request.Installments,
            InterestRate = request.InterestRate,
            PrincipalAmount = request.PrincipalAmount,
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