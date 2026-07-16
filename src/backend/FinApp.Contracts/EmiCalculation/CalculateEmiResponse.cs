namespace FinApp.Contracts.EmiCalculation;

public record CalculateEmiResponse(
    int installments,
    string interest_rate,
    decimal monthly_installment,
    decimal principal_amount,
    decimal total_interest
);