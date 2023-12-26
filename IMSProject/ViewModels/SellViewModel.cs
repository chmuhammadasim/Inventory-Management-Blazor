using System.ComponentModel.DataAnnotations;

namespace IMSProject.ViewModels
{
    public class SellViewModel
    {
        [Required]
        public string SalesNumber { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than 1")]
        public int QuantityToSell { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Price has to be greater than 1")]
        public double ProductionPrice { get; set; }
    }
}
