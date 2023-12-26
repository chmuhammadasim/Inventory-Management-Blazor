using IMS.CoreBusines;

namespace IMS.UserCases
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string DoneBy);
    }
}