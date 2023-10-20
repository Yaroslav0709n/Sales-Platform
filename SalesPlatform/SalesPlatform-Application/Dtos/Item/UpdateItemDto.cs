namespace SalesPlatform_Application.Dtos.Item
{
    public class UpdateItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string State { get; set; }
    }
}
