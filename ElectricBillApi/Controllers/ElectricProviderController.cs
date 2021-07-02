using ElectricBillApi.Exceptions;
using ElectricBillApi.Interfaces;
using ElectricBillApi.Models;
using ElectricBillApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBillApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectricProviderController : ControllerBase
    {
        private readonly IElectricProviderPicker _electricProviderPicker;

        public ElectricProviderController(IElectricProviderPicker electricProviderPicker)
        {
            _electricProviderPicker = electricProviderPicker;
        }

        [HttpGet]
        public IActionResult GetBestProvider(Address address)
        {
            try
            {
                var provider = _electricProviderPicker.FindCheapest(address);

                return Ok($"{provider.Name}, {provider.CalculatePrice(address)}, {provider.CurrentSubscribedPlant}");
            }
            catch (NoSubscribedPowerPlantException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NoValidAdressException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{provider}/subscribeToPlant")]
        public IActionResult SubscribeToPowerPlant(string provider, PowerPlant powerPlant)
        {
            try
            {
                provider.StringToProvider().Subscribe(powerPlant);

                return Ok("Successfully subscribed to powerplant.");
            }
            catch (AlreadySubscribedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoValidPowerPlantException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoProviderFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{provider}/unsubscribeToPlant")]
        public IActionResult UnsubscribeToPowerPlant(string provider, PowerPlant powerPlant)
        {
            try
            {
                provider.StringToProvider().Unsubscribe(powerPlant);

                return Ok("Unsubscribed from powerplant.");
            }
            catch (NoProviderFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
