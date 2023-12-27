using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;

namespace IMS.UserCases
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        readonly private IInventoryTransactionRepository inventoryTransactionRepository;
        readonly private IInventoryRepository inventoryRepository;
        public PurchaseInventoryUseCase(IInventoryTransactionRepository _inventoryTransactionRepository, IInventoryRepository _inventoryRepository)
        {
            this.inventoryTransactionRepository = _inventoryTransactionRepository;
            this.inventoryRepository = _inventoryRepository;
        }
        public async Task ExecteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            await this.inventoryTransactionRepository.PurchaseAsync(poNumber, inventory, quantity, inventory.Price, doneBy);
            inventory.Quantity -= quantity;
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
