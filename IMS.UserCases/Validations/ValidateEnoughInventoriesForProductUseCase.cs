using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class ValidateEnoughInventoriesForProductUseCase : IValidateEnoughInventoriesForProductUseCase
    {
        private readonly IProductRepository productRepository;
        public ValidateEnoughInventoriesForProductUseCase(IProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }
        public async Task<bool> ExecuteAsync(Product product, int quantity)
        {
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);
            foreach (var pi in prod.ProductInventories)
            {
                if (pi.InventoryQuantity * quantity > pi.Inventory.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
