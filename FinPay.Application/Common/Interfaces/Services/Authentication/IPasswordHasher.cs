using FinPay.Domain.Entities;

namespace FinPay.Application.Common.Interfaces.Services.Authentication;

public interface IPasswordHasher
{
    string HashPassword(User user);
    bool VerifyPassword(User user);
}