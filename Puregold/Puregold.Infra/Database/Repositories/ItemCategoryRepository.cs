using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.ItemCategories;
using Puregold.Domain.Items;
using Puregold.Infra.Database.Contexts;

namespace Puregold.Infra.Database.Repositories;

public sealed class ItemCategoryRepository(PuregoldDbContext context) : BaseRepository<ItemCategory>(context), IItemCategoryRepository;