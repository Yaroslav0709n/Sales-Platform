using SalesPlatform_Domain.Entities.Identity;

namespace SalesPlatform_Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountViews { get; set; }
        public int Favourites { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
