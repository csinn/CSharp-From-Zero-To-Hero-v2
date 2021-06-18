using ElectricityBillApi.Models;
using ElectricityBillApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElectricityBillApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ElectricityProviderController : ControllerBase
    {
        private readonly IElectricProviderPickerService _electricProviderPickerService;

        public ElectricityProviderController(IElectricProviderPickerService electricProviderPickerService)
        {
            _electricProviderPickerService = electricProviderPickerService;
        }

        [HttpGet]
        public IActionResult Get([FromBody] Address address)
        {
            var (provider, price) = _electricProviderPickerService.FindCheapestProviderAndPrice(address);
            return Ok(new { Name = provider.Name, Price = price});
        }
    }
}