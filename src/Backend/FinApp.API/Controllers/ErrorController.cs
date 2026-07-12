using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers;

public class ErrorControllers : ApiControllerBase
{
    [Route("exception")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(title: "An unexpected error occured.", detail: exception?.Message, statusCode: 500);
    }
}