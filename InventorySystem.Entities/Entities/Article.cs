using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Entities.Entities
{
    public class Article
    {
        [Key]
        public int IdArticle { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Required]
        [StringLength(5)]
        public string MeasurementUnit { get; set; }
        [Required]
        [StringLength(13)]
        public string Barcode { get; set; }
        [Required]
        [Min(0)]
        public int Stock { get; set; }
        [Required]
        [StringLength(5)]
        public string State { get; set; }
    }
}
