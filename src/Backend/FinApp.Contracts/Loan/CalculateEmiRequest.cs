namespace FinApp.Contracts.Loan;

public record CalculateEmiRequest(
    string tenor,
    decimal principle_amount,
    double interest_rate,
    int months
);