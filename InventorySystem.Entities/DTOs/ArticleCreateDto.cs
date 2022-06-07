
namespace InventorySystem.Entities.DTOs
{
    public class ArticleCreateDto
    {
        public string Description { get; set; }
        public string MeasurementUnit { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public string State { get; set; }
    }
}
