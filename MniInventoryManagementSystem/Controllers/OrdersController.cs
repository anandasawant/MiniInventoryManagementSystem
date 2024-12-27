using Microsoft.AspNetCore.Mvc;
using MiniInventoryManagementSystem.Contexts;
using MiniInventoryManagementSystem.Interfaces;
using MiniInventoryManagementSystem.Models;
using MiniInventoryManagementSystem.Repositories;


namespace MiniInventoryManagementSystem.Controllers
{
    public class OrdersController : Controller
    { 
    
        private readonly IProductRepository _productRepository;

        public OrdersController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult PlaceOrder() => View();

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            var message = _productRepository.PlaceOrderAsync(order.Id,order.Quantity);
            ViewBag.Message = message;
            return View();
        }
    }
}
