using IMS.CoreBusines;
using IMS.Plugins.EFCore.PluginsInterface;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly IMSContext db;
        public InventoryTransactionRepository(IMSContext _db)
        {
            this.db = _db;
        }

        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            var query = from it in db.InventoryTransactions
                        join inv in db.Inventories on it.InventoryId equals inv.InventoryId
                        where (string.IsNullOrEmpty(inventoryName) || inv.InventoryName.Contains(inventoryName, StringComparison.OrdinalIgnoreCase)) &&
                        (!dateFrom.HasValue || it.TransactionData >= dateFrom) &&
                        (!dateTo.HasValue || it.TransactionData >= dateTo) &&
                        (!transactionType.HasValue || it.ActivityType >= transactionType)
                        select it;
            return await query.Include(x => x.Inventory).ToArrayAsync();
        }

        public async Task PurchaseAsync(string poNumber, Inventory Inventory, int quantity, double price, string doneBy)
        {
            this.db.InventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = Inventory.InventoryId,
                QuantityBefore = Inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = quantity + Inventory.Quantity,
                TransactionData = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price * quantity,
            });
            await this.db.SaveChangesAsync();
        }
    }
}
