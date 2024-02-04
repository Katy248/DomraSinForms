using DomraSin.Domain.Models;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IAnswersRepository
{
    IQueryable<Answer> GetCollection(FormAnswersId formAnswersId);
}
