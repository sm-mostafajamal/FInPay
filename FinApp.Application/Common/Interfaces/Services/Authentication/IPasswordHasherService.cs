using FinApp.Domain.Entities;

namespace FinApp.Application.Common.Interfaces.Services.Authentication;

public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}