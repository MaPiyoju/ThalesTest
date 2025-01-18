using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly B_Product _product;

        public ProductController(B_Product b_Product) {
            _product = b_Product;
        }
        
        public async Task<IActionResult> Products(int page = 1, int pageSize = 10) {
            var data = await _product.GetProducts();
            
            var totalRecords = data.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var mappedData = data.Select(p => new Models.Product {
                id = p.id,
                title = p.title,
                price = p.price,
                tax = Math.Round(p.tax,2),
                description = p.description,
                images = p.images,
                creationAt = p.creationAt,
                updatedAt = p.updatedAt,
                category = p.category
            }).ToList();

            var productsToDisplay = mappedData.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;

            return View(productsToDisplay);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail([FromRoute]int id) {
            var data = await _product.GetProductById(id);

            var mappedData = new Models.Product {
                id = data.id,
                title = data.title,
                price = data.price,
                tax = Math.Round(data.tax, 2),
                description = data.description,
                images = data.images,
                creationAt = data.creationAt,
                updatedAt = data.updatedAt,
                category = data.category
            };

            return View(mappedData);
        }

        public async Task<JsonResult> CheckProduct(int id) {
            var data = await _product.GetProductById(id);
            return Json(new { exists = data != null });
        }
        

        [HttpGet]
        public async Task<JsonResult> GetProducts() {
            var data = await _product.GetProducts();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductById([FromRoute] int id) {
            var data = await _product.GetProductById(id);
            return Json(data);
        }
    }
}
