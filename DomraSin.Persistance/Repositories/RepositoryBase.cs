using System;
using System.Threading;
using System.Threading.Tasks;
using DomraSinForms.Persistence;

namespace DomraSin.Persistance;

public abstract class RepositoryBase<TEntity, TId> where TId : struct
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;

    public RepositoryBase(ApplicationDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }
    public virtual async Task BeforeDelete(TId id, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"No before delete action for {typeof(TEntity).Name}");
    }
    public virtual async Task<bool> Delete(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    } 
    public virtual Task<bool> Insert(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}