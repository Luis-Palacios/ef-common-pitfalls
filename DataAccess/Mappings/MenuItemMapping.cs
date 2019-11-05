using EFCommonPitFalls.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCommonPitFalls.DataAccess.Mappings
{
    public class MenuItemMapping : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Property(c => c.Description)
                .HasMaxLength(500);

        }
    }
}
