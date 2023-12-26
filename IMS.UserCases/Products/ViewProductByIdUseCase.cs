using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository productRepository;
        public ViewProductByIdUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public async Task<Product> ExecuteAsync(int productID)
        {
            return await this.productRepository.GetProductByIdAsync(productID);
        }
    }
}
