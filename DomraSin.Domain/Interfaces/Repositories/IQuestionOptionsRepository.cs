using DomraSin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IQuestionOptionsRepository
{
   // Task<Form> Get(string id, CancellationToken cancellationToken);
    IQueryable<QuestionOption> GetCollection(string questionId);
    Task<bool> Insert(QuestionOption questionOption, CancellationToken cancellationToken);
    Task<bool> Delete(string questionId, CancellationToken cancellationToken);
}
