using Kelly.API.Utilities;
using Kelly.APIService;
using Kelly.APIService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Kelly.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IAPIService _apiService;
        private readonly IConfiguration _configuration;
        public OrderController(IAPIService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        [HttpPost("placeorder")]
        public IActionResult PlaceOrder([FromBody]OrderAPIDto order)
        {
            IActionResult response;
            try
            {
                _apiService.ProcessOrder(order.ToOrderAPIServiceDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return response = Ok("Order processed successfully!");
        }


    }


}