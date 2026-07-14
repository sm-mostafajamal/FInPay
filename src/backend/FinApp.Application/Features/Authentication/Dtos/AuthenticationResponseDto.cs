namespace FinApp.Application.Authentication.Dtos;

public record AuthenticationResponseDto(
    string first_name,
    string last_name,
    string email,
    string access_token
);