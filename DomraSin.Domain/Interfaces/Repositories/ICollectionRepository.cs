using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface ICollectionRepository<TCollectionEntity> where TCollectionEntity : EntityBase
{
    IQueryable<TCollectionEntity> GetCollection();
}