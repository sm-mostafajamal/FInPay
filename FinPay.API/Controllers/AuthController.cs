using FinPay.Application.Features.Authentication.Commands;
using FinPay.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

public class AuthController(IMapper mapper, ISender sender) : ApiController
{
    [AllowAnonymous]
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

    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<LoginCommand>(request);
        var result = await sender.Send(command, cancellationToken);
        
        return result.Match(
            result => Ok(mapper.Map<AuthResponse>(result)),
            errors => Problem(errors)
        );   
    }
}