using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IFormAnswersRepository
{
    Task<FormAnswers> Get(FormAnswersId id, CancellationToken cancellationToken);
    IQueryable<FormAnswers> GetCollection(FormId formId);
    /// <summary>
    /// Create new <see cref="FormAnswers"/>, or update existing in database.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    bool Insert(FormAnswers item, CancellationToken cancellationToken);
}
