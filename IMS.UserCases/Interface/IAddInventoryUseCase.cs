using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}