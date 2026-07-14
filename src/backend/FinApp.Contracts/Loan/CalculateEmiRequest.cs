namespace FinApp.Contracts.Loan;

public record CalculateEmiRequest(
    string lender,
    int number_of_installments,
    decimal principle_amount,
    double interest_rate
);