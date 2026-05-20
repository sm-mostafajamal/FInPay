using ErrorOr;
using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Application.Common.Models;
using FinPay.Domain.Entities;
using FinPay.Domain.Errors;
using MediatR;

namespace FinPay.Application.Features.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<ErrorOr<AuthenticationResponseDto>>;

public class RegisterCommandHandler(IUserRepository userRepository) 
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResponseDto>>
{
    public async Task<ErrorOr<AuthenticationResponseDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var users = userRepository.GetUsers(cancellationToken);

        if(userRepository.GetUserByEmail(command.Email, cancellationToken) is User user)
        {
            return Errors.Users.DuplicateUser;
        }


        User newUser = new User (
            users.Count() + 1,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        userRepository.AddUser(newUser, cancellationToken);

        return new AuthenticationResponseDto(newUser.FirstName, newUser.LastName, newUser.Email);
    }
}