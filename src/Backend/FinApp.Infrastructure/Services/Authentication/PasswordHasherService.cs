using FinApp.Application.Common.Interfaces.Services.Authentication;
using FinApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinApp.Infrastructure.Services.Authentication;


public class PasswordHasherService() : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(new User(), password);
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        var passwordHasher = new PasswordHasher<User>();

        var result = passwordHasher.VerifyHashedPassword(new User(), hashedPassword, password);

        return result == PasswordVerificationResult.Success;
    }
}