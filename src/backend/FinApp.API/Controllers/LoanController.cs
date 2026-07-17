using FinApp.API.Common.Routes;
using FinApp.Application.Features.EmiCalculation.Commands;
using FinApp.Application.Features.EmiCalculation.Dtos;
using FinApp.Contracts.EmiCalculation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers;

public class LoanController(IMapper mapper, ISender sender) : ApiControllerBase
{
    [HttpPost(LoanRoutes.CalculateEmiRoute, Name = LoanRoutes.CalculateEmiName)]
    public async Task<IActionResult> CalculateEmi([FromBody] CalculateEmiRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CalculateEmiCommand>(request);
        var response = await sender.Send(command, cancellationToken);

        return ToActionResult(response, mapper.Map<CalculateEmiResponse>);
    }

    [HttpPost(LoanRoutes.EmiCalculationDetailRoute, Name = LoanRoutes.EmiCalculationDetailName)]
    public async Task<IActionResult> EmiCalculationDetail([FromBody] CalculateEmiRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<EmiCalculationDetailCommand>(request);
        var response = await sender.Send(command, cancellationToken); 

        return ToActionResult(response, mapper.Map<List<EmiCalculationDetailResponseDto>>);
    }
    
}