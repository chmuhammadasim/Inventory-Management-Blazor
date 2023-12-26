using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int productID);
    }
}