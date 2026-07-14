namespace FinApp.Application.Features.Loan.Dtos;

public record CalculateEmiResponseDto(
    int number_of_installments,
    string interest_rate,
    decimal monthly_installment,
    decimal principle_amount,
    decimal total_interest,
    decimal total_principle_repaid
);
