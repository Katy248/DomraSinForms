﻿using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Persistence;
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
    public DbSet<OptionsQuestion> OptionsQuestions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<OptionsQuestion>()
            .HasMany<QuestionOption>(q => q.Options)
            .WithOne(q => q.Question)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(builder);
    }
}

