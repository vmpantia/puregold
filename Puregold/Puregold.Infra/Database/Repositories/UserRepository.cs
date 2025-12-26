using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Users;
using Puregold.Infra.Database.Contexts;

namespace Puregold.Infra.Database.Repositories;

public sealed class UserRepository(PuregoldDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken = default)
    {
        var user = await GetOneAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail, cancellationToken);
        return user;
    }
}