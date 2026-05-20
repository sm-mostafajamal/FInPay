namespace FinPay.Application.Common.Models;

public record AuthenticationResponseDto(
    string first_name,
    string last_name,
    string email,
    string access_token
);