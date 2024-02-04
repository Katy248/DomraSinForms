using System.Threading;
using System.Threading.Tasks;

namespace DomraSin.Persistance;

public abstract class RepositoryBase<TEntity, TId> where TId : struct
{
    public Task<bool> Delete(TId id, CancellationToken cancellationToken)
    {
        
    } 
}