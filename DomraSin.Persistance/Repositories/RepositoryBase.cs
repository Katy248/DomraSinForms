using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DomraSin.Persistance;

public abstract class RepositoryBase<TEntity, TId> 
    where TEntity : EntityBase<TId> 
    where TId : struct
{
    protected readonly ApplicationDbContext Context;
    protected readonly ILogger Logger;

    public RepositoryBase(ApplicationDbContext context, ILogger logger)
    {
        Context = context;
        Logger = logger;
    }
    public virtual async Task BeforeDelete(TId id, CancellationToken cancellationToken)
    {
        Logger.LogDebug($"No before delete action for {typeof(TEntity).Name}");
    }
    public virtual async Task<TEntity?> Get(TId id, CancellationToken cancellationToken)
    {
        return await Context
            .Set<TEntity>()
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    } 
    public virtual Task<bool> Delete(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    } 
    
    public virtual Task<bool> EntityExists(TId id, CancellationToken cancellationToken)
    {
        return Context
            .Set<TEntity>()
            .AnyAsync(e => e.Id.Equals(id), cancellationToken);
    } 
    public virtual async Task<bool> Insert(TEntity entity, CancellationToken cancellationToken)
    {
        Logger.LogError($"Start adding new entity of type {typeof(TEntity)}");
        try
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception raised with message: '{e.Message}' while adding entity to database");
            return false;
        }

        Logger.LogError($"Finish adding entity");
        return true;
    }
}