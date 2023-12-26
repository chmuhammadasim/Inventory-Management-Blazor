using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly IMSContext db;
        private readonly IProductRepository productRepository;

        public ProductTransactionRepository(IMSContext db, IProductRepository productRepository)
        {
            this.db = db;
            this.productRepository = productRepository;

        }

        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
        {
            this.db.ProductTransactions.Add(new ProductTransaction {
                SalesOrderNumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = quantity,
                QuantityAfter = product.Quantity - quantity ,
                TransactionData = DateTime.Now,
                UnitPrice = price,
                DoneBy = doneBy
            });
            await db.SaveChangesAsync();
        }

        public async Task ProduceAsync(string productionNumber,Product product, int quantity,double price, String doneBy)
        {
            var prod =await  this.productRepository.GetProductByIdAsync(product.ProductId);
            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;
                }
            }
            this.db.ProductTransactions.Add(new ProductTransaction 
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = quantity + product.Quantity,
                TransactionData = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price,
            });
            await this.db.SaveChangesAsync();
        }
    }
}
