using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EcommerceController : ControllerBase
    {
        private readonly ILogger<EcommerceController> _logger;

        public EcommerceController(ILogger<EcommerceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ShowAll")]
        public IActionResult Show() {
            var customers = Storage.Database.Customers;
            return Ok(customers);
        }

        [HttpPut("AddProduct")]
        public IActionResult AddProduct(int idCustomer, int idProduct) {
            var result = CartService.AddToCart(idCustomer, idProduct);
            if (result) {
                return Ok();
            }
            return BadRequest("not found");
        }

        [HttpGet("Payment")]
        public IActionResult Payment(int customerId) {
            var result = CartService.Payment(customerId);
            if (result == null)
            {
                return BadRequest();
            }
            else {
                return Ok(result);
            }
        }

        [HttpGet("FinalOrder")]
        public IActionResult FinalOrder(int customerId) {
            var result = CartService.FinalOrder(customerId);
            if (result == null)
            {
                return BadRequest();
            }
            else {
                return Ok(result);
            }
        }

        [HttpGet("CheckOrderByOrderId")]
        public IActionResult CheckOrderById(string orderId) {
            var result = CartService.InformationOfOldOrder(orderId);
            if (result == null) {
                return BadRequest();
            } else
            {
                return Ok(result);
            }
        }

        //[HttpGet("CSV")]
        //public IActionResult CSV(int customerId) {
        //    var result = CartService.CsvOldOrder(customerId);
        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(result);
        //    }
        //}
        
    }
}
