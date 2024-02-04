using DomraSin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IQuestionOptionsRepository
{
    Task<QuestionOption> Get(QuestionOptionId id, CancellationToken cancellationToken);
    IQueryable<QuestionOption> GetCollection(QuestionId questionId);
    Task<bool> Insert(QuestionOption questionOption, CancellationToken cancellationToken);
    Task<bool> Delete(QuestionOptionId id, CancellationToken cancellationToken);
}
