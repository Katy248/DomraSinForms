using DomraSinForms.Domen.Models;
using DomraSinForms.Domen.Models.Answers;
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
    public DbSet<FormAnswer> Answers { get; set; }
}
