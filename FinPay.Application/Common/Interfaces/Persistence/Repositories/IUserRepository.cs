using FinPay.Domain.Entities;

namespace FinPay.Application.Common.Interfaces.Persistence.Repositories;

public interface IUserRepository
{
    public User AddUser(User user, CancellationToken cancellationToken);
    public List<User> GetUsers(CancellationToken cancellationToken);
    public User? GetUserByEmail(string email, CancellationToken cancellationToken);
}