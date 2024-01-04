using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IFormsRepository
{
    Task<Form> Get(string id, CancellationToken cancellationToken);
    IQueryable<Form> GetCollection(string formId);
    Task<bool> Insert(Form form, CancellationToken cancellationToken);
    Task<bool> Delete(string formId, CancellationToken cancellationToken);
}