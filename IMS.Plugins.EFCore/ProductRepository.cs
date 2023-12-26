using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext db;
        public ProductRepository(IMSContext db)
        {
            this.db = db;
        }

        public async Task AddProductAsync(Product product)
        {
            if (db.Product.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;
                this.db.Product.Add(product);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await this.db.Product.FindAsync(productId);
            if(product != null)
            {
                product.IsActive = false;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await db.Product.Include(x => x.ProductInventories).ThenInclude(x => x.Inventory).FirstOrDefaultAsync(x => x.ProductId == productId);
        }
        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            var data = await db.Product.Where(check => (check.ProductName.ToLower().Contains(name.ToLower()) || string.IsNullOrWhiteSpace(name)) && check.IsActive == true).ToListAsync();
            return data;
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (db.Product.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower())) return;
            var prod = await  db.Product.FindAsync( product.ProductId);

            if (prod != null) 
            {
                prod.ProductName = product.ProductName;
                prod.Quantity = product.Quantity;
                prod.Price = product.Price;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
