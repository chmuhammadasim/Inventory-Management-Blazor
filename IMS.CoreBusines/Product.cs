using IMS.CoreBusines.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusines
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity Must Be Greater or Equal To (0)")]
        public int Quantity { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Quantity Must Be Greater or Equal To (0)")]
        [Product_EnsurePriceIsGreaterThanTheInventoriesPrice]
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public List<ProductInventory>? ProductInventories { get; set; }
        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }
        public bool ValidatePrice()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;

            if (Price < TotalInventoryCost()) return false;

            return true;
        }
    }
}
