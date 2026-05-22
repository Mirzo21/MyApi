using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private static List<Product> requests = new List<Product>
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
        public IActionResult GetRequests()
        {
            return  Ok(requests);
        }

        [HttpPost]
        public IActionResult AddRequest(Product request)
        {
            request.Id = Guid.NewGuid();

            requests.Add(request);

            return Ok(requests);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(Guid id)
        {
            var request = requests.FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return NotFound("Товар не найден");
            }

            requests.Remove(request);

            return Ok(requests);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRequest(Guid id, Product updatedRequest)
        {
            var request = requests.FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return NotFound("Товар не найден");
            }

            request.Name = updatedRequest.Name;
            request.Quantity = updatedRequest.Quantity;
            request.Price = updatedRequest.Price;
            request.Category = updatedRequest.Category;

            return Ok(request);
        }
    }
}

