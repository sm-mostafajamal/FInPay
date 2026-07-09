using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinApp.API.Controllers;

[Route("api")]
[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    [Route("problem")]
    public IActionResult Problem(List<Error> errors)
    {
        if(errors.Any(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        return Problem(errors[0]);
    }
    private IActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelStateDictionary = new();

        foreach (var error in errors)
        {
            if(error.Type == ErrorType.Validation)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }           
        }

        return ValidationProblem(modelStateDictionary); 
    }
    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Validation    => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized  => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden     => StatusCodes.Status403Forbidden,
            ErrorType.NotFound      => StatusCodes.Status404NotFound,
            ErrorType.Conflict      => StatusCodes.Status409Conflict,
            ErrorType.Failure       => StatusCodes.Status500InternalServerError,
            _                       => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
}