using DomraSinForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.FormItems;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IQuestionOptionsRepository
{
    Task<QuestionOption> Get(QuestionOptionId id, CancellationToken cancellationToken);
    IQueryable<QuestionOption> GetCollection(FormItemId questionId);
    Task<bool> Insert(QuestionOption questionOption, CancellationToken cancellationToken);
    Task<bool> Delete(QuestionOptionId id, CancellationToken cancellationToken);
}
