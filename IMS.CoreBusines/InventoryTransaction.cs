using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusines
{
    public class InventoryTransaction
    {
        [Required]
        public int InventoryTransactionId { get; set; }
        [Required]
        public InventoryTransactionType ActivityType { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        public string? PONumber { get; set; }
        public string? ProductionNumber { get; set; }
        public double UnitPrice { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string DoneBy { get; set; }
        [Required]
        public Inventory Inventory { get; set; }
    }
}
