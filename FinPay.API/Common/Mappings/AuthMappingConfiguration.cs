using FinPay.Application.Features.Authentication.Commands;
using FinPay.Contracts.Authentication;
using Mapster;

namespace FinPay.API.Common.Mappings;

public class AuthMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}