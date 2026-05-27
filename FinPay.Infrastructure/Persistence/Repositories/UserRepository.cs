using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinPay.Infrastructure.Persistence.Repositories;

public class UserRepository(FinPayDbContext context) : IUserRepository
{
    private readonly FinPayDbContext _context = context;
    
    public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync();
        
        return user;
    }
    
    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
    
    // public List<User> GetUsers(CancellationToken cancellationToken)
    // {
    //     return users;
    // }
    
}