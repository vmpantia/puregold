using Microsoft.EntityFrameworkCore;
using Puregold.Domain.ItemCategories;
using Puregold.Domain.Items;
using Puregold.Domain.Users;

namespace Puregold.Infra.Database.Contexts;

public sealed class PuregoldDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PuregoldDbContext).Assembly);
}