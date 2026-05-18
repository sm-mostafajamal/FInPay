using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

[Route("/api")]
[ApiController]
public class ApiController : ControllerBase
{
    [Route("exception")]
    public IActionResult Problem(List<Error> errors)
    {
        return Ok(errors);
    }
}