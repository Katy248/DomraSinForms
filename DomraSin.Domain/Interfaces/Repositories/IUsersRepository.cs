using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IUsersRepository : ICollectionRepository<User>
{
    Task<Form> Get(string id, CancellationToken cancellationToken);
    //IQueryable<QuestionOption> GetCollection(string questionId);
    Task<bool> Insert(User user, CancellationToken cancellationToken);
    Task<bool> Delete(string userId, CancellationToken cancellationToken);
}