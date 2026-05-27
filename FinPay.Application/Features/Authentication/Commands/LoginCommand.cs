using ErrorOr;
using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Application.Common.Models;
using FinPay.Domain.Entities;
using FinPay.Domain.Errors;
using MediatR;

namespace FinPay.Application.Features.Authentication.Commands;

public record LoginCommand(
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResponseDto>>;


public class LoginCommandHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService) 
    : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResponseDto>>
{
    public async Task<ErrorOr<AuthenticationResponseDto>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if(await userRepository.GetUserByEmail(command.Email, cancellationToken) is not User user)
        {
            return Errors.Users.UserNotFound;
        }

        var token = jwtTokenService.GenerateToken(user, cancellationToken); 

        return new AuthenticationResponseDto(user.FirstName, user.LastName, user.Email, token);

    }
}