using FinApp.Domain.Entities;

namespace FinApp.Application.Common.Interfaces.Services;

public interface IJwtTokenService
{
    public string GenerateToken(User user);
}