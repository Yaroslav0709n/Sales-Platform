using System.ComponentModel.DataAnnotations.Schema;

namespace SalesPlatform_Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string Caption { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
