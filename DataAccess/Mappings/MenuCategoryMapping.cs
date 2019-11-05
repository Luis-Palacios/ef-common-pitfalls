using EFCommonPitFalls.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCommonPitFalls.DataAccess.Mappings
{
    public class MenuCategoryMapping : IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(EntityTypeBuilder<MenuCategory> builder)
        {
            builder.Property(c => c.ImageUrl)
                .HasMaxLength(500);
        }
    }
}
