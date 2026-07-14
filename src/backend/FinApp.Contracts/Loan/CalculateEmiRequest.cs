namespace FinApp.Contracts.Loan;

public record CalculateEmiRequest(
    string lender,
    int installments,
    decimal principle_amount,
    double interest_rate
);