using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommonPitFalls.DataAccess
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
    }
}
