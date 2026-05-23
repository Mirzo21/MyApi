using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Ноутбук",
                Quantity = 5,
                Price = 35000,
                Category = "Техника"
            }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();

            products.Add(product);

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Товар не найден");
            }

            products.Remove(product);

            return Ok(products);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Товар не найден");
            }

            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;
            product.Category = updatedProduct.Category;

            return Ok(product);
        }
    }
}
