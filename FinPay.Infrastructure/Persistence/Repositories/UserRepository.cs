using FinPay.Application.Common.Interfaces.Persistence.Repositories;
using FinPay.Domain.Entities;

namespace FinPay.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> users = new();

    public User AddUser(User user, CancellationToken cancellationToken)
    {
        users.Add(user);

        return user;
    }
    public List<User> GetUsers(CancellationToken cancellationToken)
    {
        return users;
    }
    public User? GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return users.FirstOrDefault(user => user.Email == email);
    }
}