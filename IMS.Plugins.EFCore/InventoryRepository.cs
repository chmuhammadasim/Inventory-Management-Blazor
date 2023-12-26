using IMS.CoreBusines;
using IMS.Plugins.EFCore;
using IMS.Plugins;
using Microsoft.EntityFrameworkCore;
using IMS.Plugins.EFCore.PluginsInterface;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        public readonly IMSContext db;

        public InventoryRepository(IMSContext dbs)
        {
           db = dbs;
        }
        //public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        //{
        //    return await db.Inventories.Where(check => check.InventoryName.ToLower().Contains(name.ToLower()) || string.IsNullOrWhiteSpace(name)).ToListAsync();
        //}
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.db.Inventories.Where(x => x.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            if (db.Inventories.Any(x => x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return;

            this.db.Inventories.Add(inventory);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            //if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return;

            if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return;


            var inv = await this.db.Inventories.FindAsync(inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;

                await db.SaveChangesAsync();
            }
        }
        public async Task<Inventory?> GetInventoriesByIdAsync(int inventoryId)
        {
            return await this.db.Inventories.FindAsync(inventoryId);
        }
    }
}
