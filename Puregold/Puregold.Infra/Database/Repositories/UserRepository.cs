using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Users;
using Puregold.Infra.Database.Contexts;

namespace Puregold.Infra.Database.Repositories;

public sealed class UserRepository(PuregoldDbContext context) : BaseRepository<User>(context), IUserRepository;