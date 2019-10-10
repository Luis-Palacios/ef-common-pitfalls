using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommonPitFalls.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuCategory> MenuCategories { get; set; }

        public RestaurantContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;MultipleActiveResultSets=true"
                );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
