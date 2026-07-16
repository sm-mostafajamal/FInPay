using FinApp.Application.Features.Authentication.Commands;
using FinApp.Application.Features.EmiCalculation.Commands;
using FinApp.Contracts.Authentication;
using FinApp.Contracts.EmiCalculation;
using Mapster;

namespace FinApp.API.Common.Mappings;

public class LoanConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CalculateEmiRequest, CalculateEmiCommand>()
            .MapWith(src => new CalculateEmiCommand
            {
                
                Lender = src.lender,
                Installments = src.installments,
                PrincipalAmount = src.principal_amount,
                InterestRate = src.interest_rate
            });
    }
}