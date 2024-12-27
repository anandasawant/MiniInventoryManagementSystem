using MiniInventoryManagementSystem.Interfaces;
using MiniInventoryManagementSystem.Models;

namespace MiniInventoryManagementSystem.Repositories
{
    public class OrderService : IOrderService
    {
    //    private readonly IProductRepository _productRepository;

    //    public OrderService(IProductRepository productRepository)
    //    {
    //        _productRepository = productRepository;
    //    }

    //    public string PlaceOrder(Order order)
    //    {
    //        var product = _productRepository.GetById(order.ProductId);
    //        if (product == null)
    //        {
    //            return "Product not found.";
    //        }

    //        if (product.Stock < order.Quantity)
    //        {
    //            return "Insufficient stock.";
    //        }

    //        product.Stock -= order.Quantity;
    //        return "Order placed successfully.";
    //    }
    }
}

