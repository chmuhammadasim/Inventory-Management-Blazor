using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}