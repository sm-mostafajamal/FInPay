namespace FinPay.Contracts.Authentication;

public record AuthResponse(
    string first_name,
    string last_name,
    string email
);