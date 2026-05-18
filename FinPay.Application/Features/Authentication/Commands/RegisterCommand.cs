using ErrorOr;
using FinPay.Application.Authentication;
using FinPay.Application.Interfaces.Repositories;
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
) : IRequest<ErrorOr<AuthenticationResponse>>;

public class RegisterCommandHandler(IUserRepository userRepository) 
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResponse>>
{
    public async Task<ErrorOr<AuthenticationResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
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

        return new AuthenticationResponse(newUser.FirstName, newUser.LastName, newUser.Email);
    }
}