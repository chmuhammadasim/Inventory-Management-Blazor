using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productInventory;
        public AddProductUseCase(IProductRepository productInventory)
        {
            this.productInventory = productInventory;
        }
        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;
            await productInventory.AddProductAsync(product);
        }
    }
}
