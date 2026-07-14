using MediatR;
using ErrorOr;
using FinApp.Application.Features.Loan.Dtos;

public record CalculateEmiCommand(
    string Lender,
    int Installments,
    decimal PrincipleAmount,
    double InterestRate
) : IRequest<ErrorOr<CalculateEmiResponseDto>>;

public class CalculateEmiHandler : IRequestHandler<CalculateEmiCommand, ErrorOr<CalculateEmiResponseDto>>
{
    public async Task<ErrorOr<CalculateEmiResponseDto>> Handle(CalculateEmiCommand request, CancellationToken cancellationToken)
    {
        
        
        return new CalculateEmiResponseDto(request.Installments, $"{request.InterestRate}%", 5428, request.PrincipleAmount, 50000, 150000);

    }
}