namespace FinApp.Application.Features.EmiCalculation.Dtos;

public record CalculateEmiResponseDto(
    int installments,
    string interest_rate,
    decimal monthly_installment,
    decimal principal_amount,
    decimal total_interest,
    decimal total_repayment
);
