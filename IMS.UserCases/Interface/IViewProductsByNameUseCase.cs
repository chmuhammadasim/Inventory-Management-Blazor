using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IViewProductsByNameUseCase
    {
        Task<List<Product>> ExecuteAsync(string name = "");
    }
}