namespace FinApp.Contracts.Loan;

public record CalculateEmiRequest(
    string lender,
    int installments,
    decimal principal_amount,
    decimal interest_rate
);