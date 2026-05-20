namespace FinPay.Application.Common.Interfaces.Services;

public interface IJwtTokenService
{
    public string GenerateToken();
}