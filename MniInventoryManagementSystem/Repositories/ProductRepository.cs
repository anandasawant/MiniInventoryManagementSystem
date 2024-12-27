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

        public async Task<bool> PlaceOrderAsync(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null || product.Stock < quantity) return false;

            product.Stock -= quantity;

            var order = new Order
            {
                ProductId = productId,
                Quantity = quantity
               
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
