using MiniInventoryManagementSystem.Models;

namespace MiniInventoryManagementSystem.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        //Task<bool> PlaceOrderAsync(int productId, int quantity);
        Task<bool> ExistsByNameAsync(string name);
        Task<String> PlaceOrderAsync(int productId, int quantity);
    }
}
