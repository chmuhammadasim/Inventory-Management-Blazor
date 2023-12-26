using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UserCases
{
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        public EditInventoryUseCase(IInventoryRepository _inventoryRepository)
        {
            this.inventoryRepository = _inventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
