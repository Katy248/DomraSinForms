using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DomraSinForms.Persistence.Repositories;

public class UserRepository : RepositoryBase<User, UserId>, IUsersRepository
{
    public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context, logger)
    {
    }
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        Logger.LogDebug($"Start searching for user with email \"{email}\"");
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
