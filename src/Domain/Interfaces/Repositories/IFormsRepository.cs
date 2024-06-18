using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IFormsRepository
{
    Task<Form> Get(FormId id, CancellationToken cancellationToken);
    IQueryable<Form> GetCollection(UserId userId);
    Task<bool> Insert(Form form, CancellationToken cancellationToken);
    Task<bool> Delete(FormId id, CancellationToken cancellationToken);
}