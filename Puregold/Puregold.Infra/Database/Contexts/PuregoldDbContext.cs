using Microsoft.EntityFrameworkCore;
using Puregold.Domain.ItemCategories;
using Puregold.Domain.Items;

namespace Puregold.Infra.Database.Contexts;

public sealed class PuregoldDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
}