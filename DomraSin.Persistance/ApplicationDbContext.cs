using DomraSin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DomraSin.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormAnswers> FormAnswers { get; set; }
        public DbSet<FormItem> FormItems { get; set; }
        public DbSet<ScoreType> ScoreTypes{ get; set; }
    }
}
