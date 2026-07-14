using MediatR;
using ErrorOr;
using FinApp.Application.Features.Loan.Dtos;

public record CalculateEmiCommand(
    string Lender,
    int TenorMonths,
    decimal PrincipleAmount,
    double InterestRate
) : IRequest<ErrorOr<CalculateEmiResponseDto>>;

public class CalculateEmiHandler : IRequestHandler<CalculateEmiCommand, ErrorOr<CalculateEmiResponseDto>>
{
    public async Task<ErrorOr<CalculateEmiResponseDto>> Handle(CalculateEmiCommand request, CancellationToken cancellationToken)
    {
        
        
        return new CalculateEmiResponseDto(request.TenorMonths, "14.05%", 5428, 100000, 50000, 150000);

    }
}