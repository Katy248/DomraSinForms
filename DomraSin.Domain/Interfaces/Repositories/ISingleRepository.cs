using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface ISingleRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity> Get(string id, CancellationToken cancellationToken = default);
}