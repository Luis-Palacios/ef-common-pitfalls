using EFCommonPitFalls.DataAccess.Mappings;

namespace EFCommonPitFalls.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public int MenuCategoryId { get; set; }

        public virtual MenuCategory MenuCategory { get; set; }
    }
}
