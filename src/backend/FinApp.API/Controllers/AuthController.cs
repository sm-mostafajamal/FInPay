    using FinApp.API.Common.Routes;
    using FinApp.Application.Features.Authentication.Commands;
    using FinApp.Contracts.Authentication;
    using MapsterMapper;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace FinApp.API.Controllers;

    [AllowAnonymous]
    public class AuthController(IMapper mapper, ISender sender) : ApiControllerBase
    {
        [HttpPost(AuthRoutes.RegisterRoute.Register, Name = AuthRoutes.RegisterRoute.RegisterName)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var command = mapper.Map<RegisterCommand>(request);
            var result = await sender.Send(command, cancellationToken);
            
            return ToActionResult(result, mapper.Map<AuthResponse>); 
        }

        [HttpPost(AuthRoutes.LoginRoute.Login, Name = AuthRoutes.LoginRoute.LoginName)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = mapper.Map<LoginCommand>(request);
            var result = await sender.Send(command, cancellationToken);
            
            return ToActionResult(result, mapper.Map<AuthResponse>); 
        }
    }