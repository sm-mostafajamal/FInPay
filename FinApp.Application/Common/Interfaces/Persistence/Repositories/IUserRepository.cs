using FinApp.Domain.Entities;

namespace FinApp.Application.Common.Interfaces.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    // public List<User> GetUsers(CancellationToken cancellationToken);
}