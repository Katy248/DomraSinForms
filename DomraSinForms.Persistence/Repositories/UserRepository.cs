using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;

namespace DomraSin.Persistance;

public class UserRepository : RepositoryBase<User, UserId>, IUsersRepository
{
    public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context, logger)
    {
    }
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context
            .Users
            .FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
    }

    public Task<bool> UserExists(string email, CancellationToken cancellationToken)
    {
        return Context
            .Users
            .AnyAsync(u => u.Email == email, cancellationToken);
    }
}
