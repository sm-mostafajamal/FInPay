namespace FinPay.Application.Authentication;

public record AuthenticationResponse(
    string first_name,
    string last_name,
    string email
);