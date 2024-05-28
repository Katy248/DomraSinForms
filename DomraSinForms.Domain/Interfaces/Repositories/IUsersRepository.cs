using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User?> Get(UserId id, CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    Task<bool> UserExists(string email, CancellationToken cancellationToken);
    Task<bool> Insert(User user, CancellationToken cancellationToken);
    Task<bool> Delete(UserId id, CancellationToken cancellationToken);
}