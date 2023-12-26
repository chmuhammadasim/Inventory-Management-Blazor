using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}