using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniInventoryManagementSystem.Contexts;
using MiniInventoryManagementSystem.Interfaces;
using MiniInventoryManagementSystem.Models;

namespace MiniInventoryManagementSystem.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }

       


        public async Task<string> PlaceOrderAsync(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null || quantity > product.Stock)
            {
                
                return "Insufficient stock or invalid product.";
            }

            product.Stock -= quantity;
            var order = new Order();
            order.ProductId = productId;    
            order.Quantity = quantity;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return  "Order placed successfully!";
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Products
                .AnyAsync(p => p.Name == name);
        }

    }
}
