using EFCommonPitFalls.DataAccess.Mappings;
using EFCommonPitFalls.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCommonPitFalls.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }

        public RestaurantContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Override custom convention for string fields set them with MaxLenght = 250 and IsNullable = False
            modelBuilder.Model.GetEntityTypes()
                            .SelectMany(e => e.GetProperties())
                            .Where(p => (p.PropertyInfo != null) ? p.PropertyInfo.PropertyType == typeof(string) : false)
                            .ToList()
                            .ForEach(p =>
                            {
                                p.SetMaxLength(250);
                                p.IsNullable = false;
                            });

            modelBuilder.ApplyConfiguration(new MenuCategoryMapping());
            modelBuilder.ApplyConfiguration(new MenuItemMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
