using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusines
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        public string InventoryName { get; set; } = string.Empty;
        [Range(0,int.MaxValue,ErrorMessage ="Quantity Must Be Greater or Equal To (0)")]
        public int Quantity { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price Must Be Greater or Equal To (0)")]
        public double Price { get; set; }

        public List<ProductInventory> ProductInventories { get; set; }
    }
}
