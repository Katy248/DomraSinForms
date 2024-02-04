using DomraSin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IScoreTypesRepository
{
    Task<ScoreType> Get(ScoreTypeId id, CancellationToken cancellationToken);
    IQueryable<ScoreType> GetCollection(FormId formId);
    Task<bool> Insert(ScoreType scoreType, CancellationToken cancellationToken);
    Task<bool> Delete(ScoreTypeId id, CancellationToken cancellationToken);
}
