using FinApp.Application.Common.Interfaces.Persistence.Repositories;
using FinApp.Application.Common.Interfaces.Services.Authentication;
using FinApp.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FinApp.Infrastructure.Seed;

public static class IdentitySeeder
{
    public static async Task SuperAdminSeedAsync(this IServiceProvider service)
    {
        var serviceProvider = service.CreateScope().ServiceProvider;
        var userRepository = serviceProvider.GetRequiredService<IUserRepository>();
        var passwordHasherService = serviceProvider.GetRequiredService<IPasswordHasherService>();

        var email = "super.admin@finapp.com";
        
        if (await userRepository.GetUserByEmail(email, CancellationToken.None) is null)
        {
            userRepository.AddUserAsync(new User(
                "super",
                "admin",
                "+8801855555555",
                email,
                passwordHasherService.HashPassword("Nop@ss1234")
            ), CancellationToken.None);
        }
    }
}