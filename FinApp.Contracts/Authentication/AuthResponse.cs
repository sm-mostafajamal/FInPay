namespace FinApp.Contracts.Authentication;

public record AuthResponse(
    string first_name,
    string last_name,
    string email,
    string access_token
);