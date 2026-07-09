namespace FinApp.Contracts.Authentication;

public record RegisterRequest(
    string first_name,
    string last_name,
    string phone_number,
    string email,
    string password,
    string confirm_password
);