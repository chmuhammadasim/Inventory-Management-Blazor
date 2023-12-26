using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}