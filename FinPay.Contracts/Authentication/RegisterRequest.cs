namespace FinPay.Contracts.Authentication;

public record RegisterRequest(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword
);