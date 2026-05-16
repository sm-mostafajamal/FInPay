namespace FinPay.Contracts.Authentication;

public record RegisterRequest(
    string first_name,
    string last_name,
    string email,
    string password,
    string confirm_password
);