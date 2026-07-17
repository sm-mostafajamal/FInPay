namespace FinApp.Contracts.EmiCalculation;

public record EmiResponse(
    int month,
    decimal opening_balance,
    decimal monthly_emi,
    decimal monthly_interest,
    decimal monthly_principal,
    decimal closing_balance,
    decimal total_remaining_interest,
    decimal total_repayment
);