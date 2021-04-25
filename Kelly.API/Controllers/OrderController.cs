using Kelly.API.Utilities;
using Kelly.APIService;
using Kelly.APIService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Kelly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IAPIService _apiService;
        private readonly IConfiguration _configuration;
        public OrderController(IAPIService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        /// <summary>
        /// The PlaceOrder endpoint accepts credit card information, order item and amount to place an order. 
        /// </summary>
        /// <param name="order">(ItemName, Amount, CreditCardInfo)</param>
        /// <returns>HttpStatusCode indicating the success of the PlaceOrder request.</returns>
        [HttpPost("placeorder")]
        public async Task<IActionResult> PlaceOrder([FromBody]OrderAPIDto order)
        {
            HttpStatusCode result;
            try
            {
               result = await _apiService.PlaceOrder(order.ToOrderAPIServiceDto());
                if(result != HttpStatusCode.OK)
                {
                    return StatusCode((int)result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("Order processed successfully!");
        }
    }
}