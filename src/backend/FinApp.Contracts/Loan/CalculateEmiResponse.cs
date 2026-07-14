namespace FinApp.Contracts.Loan;

public record CalculateEmiResponse(
    int installments,
    string interest_rate,
    decimal monthly_installment,
    decimal principle_amount,
    decimal total_interest,
    decimal total_principle_repaid
);