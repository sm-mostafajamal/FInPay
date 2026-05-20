using FinPay.Domain.Entities;

namespace FinPay.Application.Common.Interfaces.Services;

public interface IJwtTokenService
{
    public string GenerateToken(User user);
}