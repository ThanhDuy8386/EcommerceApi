using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("SearchProduct")]
        public IActionResult Search(string search) {
            var result = Services.ProductService.SearchProduct(search);
            if (result == null)
            {
                return NotFound();
            }
            else { 
                return Ok(result);
            }
        }
    }
}
