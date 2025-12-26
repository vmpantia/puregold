using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Puregold.Domain.Items;

namespace Puregold.Infra.Database.Contexts.Configurations;

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(itm => itm.Id);
        builder.HasOne(itm => itm.Category)
            .WithMany(itmc => itmc.Items)
            .HasForeignKey(itm => itm.ItemCategoryId)
            .IsRequired();
    }
}