using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Interfaces.Repositories;

public interface IAnswersRepository
{
    IQueryable<Answer> GetCollection(FormAnswersId formAnswersId);
}
