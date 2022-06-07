using DataAnnotationsExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Entities.Entities
{
    public class Movement
    {
        [Key]
        public int IdMovement { get; set; }
        [Display(Name = "Article")]
        public virtual int IdArticle { get; set; }
        [Required]
        [ForeignKey("IdArticle")]
        public virtual Article Articles { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(50)]
        public string Concept { get; set; }
        [Required]
        [StringLength(5)]
        public string State { get; set; }
        [Required]
        [Min(-1)]
        [Max(1)]
        public sbyte MovementType { get; set; }
        
    }
}
