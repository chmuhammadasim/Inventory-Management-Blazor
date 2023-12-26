using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IProductTransactionRepository productTransactionRepository;
        public ProduceProductUseCase(IInventoryRepository _inventoryRepository, IProductRepository _productRepository, IInventoryTransactionRepository _inventoryTransactionRepository, IProductTransactionRepository _productTransactionRepository)
        {
            this.inventoryRepository = _inventoryRepository;
            this.productRepository = _productRepository;
            this.inventoryTransactionRepository = _inventoryTransactionRepository;
            this.productTransactionRepository = _productTransactionRepository;
        }
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string DoneBy)
        {
            await this.productTransactionRepository.ProduceAsync(productionNumber, product, quantity, product.Price, DoneBy);
            product.Quantity += quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
