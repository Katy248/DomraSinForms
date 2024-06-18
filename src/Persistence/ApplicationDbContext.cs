using DomraSinForms.Domain.Models.FormItems;
using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormAnswers> FormAnswers { get; set; }
    public DbSet<FormItem> FormItems { get; set; }
    public DbSet<ScoreType> ScoreTypes { get; set; }
    public DbSet<PictureItem> PictureItems { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Answer>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<AnswerId>(
                id => id.Value, value => new(value)));
        builder.Entity<Form>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<FormId>(
                id => id.Value, value => new(value)));
        builder.Entity<FormAnswers>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<FormAnswersId>(
                id => id.Value, value => new(value)));
        builder.Entity<FormItem>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<FormItemId>(
                id => id.Value, value => new(value)));
        builder.Entity<ScoreType>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<ScoreTypeId>(
                id => id.Value, value => new(value)));
        builder.Entity<User>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<UserId>(
                id => id.Value, value => new(value)));
        builder.Entity<QuestionOption>()
            .Property(a => a.Id)
            .HasConversion(new ToGuidValueConverter<QuestionOptionId>(
                id => id.Value, value => new(value)));

        builder.Entity<User>()
            .HasMany(u => u.UserForms)
            .WithOne(f => f.Creator);
        builder.Entity<Form>()
            .HasMany(f => f.Redactors)
            .WithMany(u => u.AllowedToRedactForms);
        base.OnModelCreating(builder);
    }
}