using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User> Get(string id, CancellationToken cancellationToken);
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
    //IQueryable<QuestionOption> GetCollection(string questionId);

    Task<bool> UserExists(string email, CancellationToken cancellationToken);
    Task<bool> Insert(User user, CancellationToken cancellationToken);
    Task<bool> Delete(string userId, CancellationToken cancellationToken);
}