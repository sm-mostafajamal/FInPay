using FinPay.Application.Features.Authentication.Commands;
using FinPay.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

public class AuthController(IMapper mapper, ISender sender) : ApiContoller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var result = await sender.Send(command);
        // return Ok(result);
            return result.Match(
        authResponse => Ok(result.Value),
        errors => Problem(errors.First().Description)
    );
    }
}