using IMS.CoreBusines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.PluginsInterface
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, double price, String doneBy);
        Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price ,string doneBy);
    }
}
