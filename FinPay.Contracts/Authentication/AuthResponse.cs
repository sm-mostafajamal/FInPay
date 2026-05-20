namespace FinPay.Contracts.Authentication;

public record AuthResponse(
    string first_name,
    string last_name,
    string email,
    string phone_number,
    string access_token
);