using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface ISellProductUseCase
    {
        Task ExecteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}