using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IValidateEnoughInventoriesForProductUseCase
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}