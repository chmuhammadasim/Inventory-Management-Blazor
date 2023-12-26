using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExcuteAsync(int inventoryId);
    }
}