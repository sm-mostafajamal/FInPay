using ErrorOr;
using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Application.Common.Interfaces.Services.Authentication;
using FinPay.Application.Common.Models;
using FinPay.Domain.Entities;
using FinPay.Domain.Errors;
using MediatR;

namespace FinPay.Application.Features.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<ErrorOr<AuthenticationResponseDto>>;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtTokenService jwtTokenService,
    IPasswordHasherService passwordHasher        
) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResponseDto>>
{
    public async Task<ErrorOr<AuthenticationResponseDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if(await userRepository.GetUserByEmail(command.Email, cancellationToken) is User user)
        {
            return Errors.Users.DuplicateUser;
        }

        var newUser = await userRepository.AddUserAsync(new User (
            command.FirstName,
            command.LastName,
            command.PhoneNumber,
            command.Email,
            passwordHasher.HashPassword(command.Password)
        ), cancellationToken);
        var token = jwtTokenService.GenerateToken(newUser);

        return new AuthenticationResponseDto(newUser.FirstName, newUser.LastName, newUser.Email, token);
    }
}