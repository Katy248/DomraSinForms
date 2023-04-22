using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forms.Mvc.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<QuestionBase> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<FormAnswers> FormAnswers { get; set; }
    public DbSet<Answer> AnswerBlocks { get; set; }
    public DbSet<TextQuestion> TextQuestions { get; set; }
    public DbSet<NumberQuestion> NumberQuestions { get; set; }
    public DbSet<RadioQuestion> RadioQuestions { get; set; }
    public DbSet<CheckQuestion> CheckQuestions { get; set; }
}

