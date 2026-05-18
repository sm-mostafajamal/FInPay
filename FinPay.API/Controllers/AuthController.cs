using FinPay.Application.Features.Authentication.Commands;
using FinPay.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

public class AuthController(IMapper mapper, ISender sender) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var result = await sender.Send(command, cancellationToken);
        
        
        return result.Match(
            result => Ok(mapper.Map<AuthResponse>(result)),
            errors => Problem(errors)
        );
    }
}