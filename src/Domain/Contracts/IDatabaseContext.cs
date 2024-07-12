using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Domain.Models.Versions;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Domain.Contracts;

public interface IDatabaseContext
{
    DbSet<Form> Forms { get; }
    DbSet<FormVersion> FormVersions { get; }
    DbSet<QuestionBase> Questions { get; }
    DbSet<Answer> Answers { get; }
    DbSet<FormAnswers> FormAnswers { get; }
    DbSet<Answer> AnswerBlocks { get; }
    DbSet<TextQuestion> TextQuestions { get; }
    DbSet<OptionsQuestion> OptionsQuestions { get; }
    DbSet<QuestionOption> QuestionOptions { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}
