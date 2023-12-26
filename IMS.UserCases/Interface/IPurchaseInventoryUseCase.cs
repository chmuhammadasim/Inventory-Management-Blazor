using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
    }
}