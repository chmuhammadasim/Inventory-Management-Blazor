using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        public ViewInventoryByIdUseCase(IInventoryRepository _inventoryRepository)
        {
            this.inventoryRepository = _inventoryRepository;
        }
        public async Task<Inventory> ExcuteAsync(int inventoryId)
        {
            return await this.inventoryRepository.GetInventoriesByIdAsync(inventoryId);
        }
    }
}
