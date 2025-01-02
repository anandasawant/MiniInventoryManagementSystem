using Microsoft.AspNetCore.Mvc;
using MiniInventoryManagementSystem.Contexts;
using MiniInventoryManagementSystem.Interfaces;
using MiniInventoryManagementSystem.Models;


namespace MiniInventoryManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index() => View(await _productRepository.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (await _productRepository.ExistsByNameAsync(product.Name))
            {
                ModelState.AddModelError("Name", "Product with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productRepository.DeleteAsync(product.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}