using FinApp.Application.Common.Interfaces.Persistence.Repositories;
using FinApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Infrastructure.Persistence.Repositories;

public class UserRepository(FinAppDbContext context) : IUserRepository
{
    private readonly FinAppDbContext _context = context;
    
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