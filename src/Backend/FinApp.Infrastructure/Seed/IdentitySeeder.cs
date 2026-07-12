using FinApp.Application.Common.Interfaces.Persistence.Repositories;
using FinApp.Application.Common.Interfaces.Services.Authentication;
using FinApp.Domain.Entities;
using FinApp.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Infrastructure.Seed;

public static class IdentitySeeder
{
    public static async Task SuperAdminSeedAsync(this IServiceProvider service)
    {
        var serviceProvider = service.CreateScope().ServiceProvider;
        var db = serviceProvider.GetRequiredService<FinAppDbContext>();

        await db.Database.MigrateAsync();

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