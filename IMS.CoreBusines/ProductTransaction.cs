using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusines
{
    public class ProductTransaction
    {
        [Required]
        public int ProductTransactionId { get; set; }
        [Required]
        public ProductTransactionType ActivityType { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        public string PONumber { get; set; }
        public string ProductionNumber { get; set; }
        public string SalesOrderNumber { get; set; }
        public double UnitPrice { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        [Required]
        public DateTime TransactionData { get; set; }
        [Required]
        public string DoneBy { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
