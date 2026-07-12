using FinApp.Application.Features.Authentication.Commands;
using FinApp.Contracts.Authentication;
using Mapster;

namespace FinApp.API.Common.Mappings;

public class AuthMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}