﻿using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;
        public SellProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;

        }
        public async Task ExecteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            await this.productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, product.Price, doneBy);
            product.Quantity -= quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
