using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinPay.API.Controllers;

public class ErrorControllers : ApiController
{
    [Route("exception")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(title: "An unexpected error occured.", detail: exception?.Message, statusCode: 500);
    }
}