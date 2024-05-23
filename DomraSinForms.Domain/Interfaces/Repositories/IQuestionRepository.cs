using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.FormItems;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IQuestionRepository
{
    Task<Question> Get(FormItemId id, CancellationToken cancellationToken);
    IQueryable<Question> GetCollection(FormId id);
    Task<bool> Insert(Question question, CancellationToken cancellationToken);
    Task<bool> Delete(FormItemId id, CancellationToken cancellationToken);
}
