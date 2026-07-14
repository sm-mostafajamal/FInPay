using FinApp.API.Common.Routes;
using FinApp.Contracts.Loan;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers;

public class LoanController(IMapper mapper, ISender sender) : ApiControllerBase
{
    [HttpPost(LoanRoutes.CalculateEmi, Name = LoanRoutes.CalculateEmiName)]
    public async Task<IActionResult> CalculateEmi([FromBody] CalculateEmiRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CalculateEmiCommand>(request);
        var response = await sender.Send(command, cancellationToken);

        return ToActionResult(response, mapper.Map<CalculateEmiResponse>);
    }
    
}