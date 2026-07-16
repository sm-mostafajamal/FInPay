namespace FinApp.Contracts.EmiCalculation;

public record EmiCalculationDetailResponse(
    int month,
    decimal opening_balance,
    decimal monthly_emi,
    decimal monthly_interest,
    decimal monthly_principal,
    decimal closing_balance
);