using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> DisplayProducts()
        {
            var data = await _repo.GetProductsAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductData data)
        {
            await _repo.AddProductsAsync(data);
            return RedirectToAction("DisplayProducts");
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int Id)
        {
            var product = await _repo.FindProductAsync(Id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductData product)
        {
            await _repo.UpdateProductAsync(product);
            return RedirectToAction("DisplayProducts");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            await _repo.DeleteProductAsync(Id);
            return RedirectToAction("DisplayProducts");
        }
    }
}
