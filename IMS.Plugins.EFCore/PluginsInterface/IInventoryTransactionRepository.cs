using IMS.CoreBusines;

namespace IMS.Plugins.EFCore.PluginsInterface
{
    public interface IInventoryTransactionRepository
    {
        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
        public Task PurchaseAsync(string poNumber, Inventory Inventory, int quantity, double price, string doneBy);
    }
}
