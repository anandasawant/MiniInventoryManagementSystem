using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> PlaceOrderAsync(Order order)
        {
            var message = await _productRepository.PlaceOrderAsync(order.ProductId, order.Quantity);
            ViewBag.Message = message;
            return View();
        }



    }
}
