using IMS.CoreBusines;
using IMS.Plugins.EFCore;
using IMS.Plugins.EFCore.PluginsInterface;
namespace IMS.UserCases
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameUseCase(IInventoryRepository iinventoryRepository)
        {  
            inventoryRepository = iinventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name)
        {
            return await inventoryRepository.GetInventoriesByName(name);
        }
    }
}
