using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Items;
using Puregold.Infra.Database.Contexts;

namespace Puregold.Infra.Database.Repositories;

public sealed class ItemRepository(PuregoldDbContext context) : BaseRepository<Item>(context), IItemRepository;