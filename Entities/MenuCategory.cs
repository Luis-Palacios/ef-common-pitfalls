using EFCommonPitFalls.DataAccess.Mappings;
using System;
using System.Collections.Generic;

namespace EFCommonPitFalls.Entities
{
    public class MenuCategory
    {
        public MenuCategory()
        {
            MenuItems = new List<MenuItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public bool Active { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
