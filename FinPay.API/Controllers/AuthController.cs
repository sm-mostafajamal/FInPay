using FinPay.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

public class AuthController : ApiContoller
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        return Ok(request);       
    }
}