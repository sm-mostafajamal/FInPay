using FinPay.Domain.Entities;

namespace FinPay.Application.Common.Interfaces.Services.Authentication;

public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}