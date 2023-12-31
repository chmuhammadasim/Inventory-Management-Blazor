﻿using IMS.CoreBusines;
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
            if (db.Product.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower())) return;
            db.Product.Add(product);
            await db.SaveChangesAsync();

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
            return await this.db.Product.Where(x => (x.ProductName.ToLower().IndexOf(name.ToLower()) >= 0 || string.IsNullOrWhiteSpace(name)) && x.IsActive == true).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (db.Product.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower())) return;

            var prod = await db.Product.FindAsync(product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
