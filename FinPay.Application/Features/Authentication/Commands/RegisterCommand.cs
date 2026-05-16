using ErrorOr;
using FinPay.Application.Authentication;
using MediatR;

namespace FinPay.Application.Features.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<ErrorOr<AuthenticationResponse>>;

public class RegisterCommandHandler() 
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResponse>>
{
    public async Task<ErrorOr<AuthenticationResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         
        return new AuthenticationResponse(command.FirstName, command.LastName, command.Email);
    }
}