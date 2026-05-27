using ErrorOr;
using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Application.Common.Interfaces.Services.Authentication;
using FinPay.Application.Common.Models;
using FinPay.Domain.Entities;
using FinPay.Domain.Errors;
using MediatR;

namespace FinPay.Application.Features.Authentication.Commands;

public record LoginCommand(
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResponseDto>>;


public class LoginCommandHandler(
    IUserRepository userRepository, 
    IJwtTokenService jwtTokenService,
    IPasswordHasherService passwordHasherService
) 
    : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResponseDto>>
{
    public async Task<ErrorOr<AuthenticationResponseDto>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var dummyHash = "$2a$12$dummyHashToPreventTimingAttackOnLogin";
        var user = await userRepository.GetUserByEmail(command.Email, cancellationToken);
        
        if(user is not User || !passwordHasherService.VerifyPassword(user?.Password ?? dummyHash, command.Password))
        {
            return Errors.Users.InvalidUserCredential;
        }

        var token = jwtTokenService.GenerateToken(user); 

        return new AuthenticationResponseDto(user.FirstName, user.LastName, user.Email, token);

    }
}