using System;

namespace InventorySystem.Entities.DTOs
{
    public class MovementCreateDto
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Concept { get; set; }
        public string State { get; set; }
        public int MovementType { get; set; }
    }
}
