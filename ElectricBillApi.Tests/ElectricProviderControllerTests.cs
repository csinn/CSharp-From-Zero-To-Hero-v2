using ElectricBillApi.Controllers;
using ElectricBillApi.Services;
using ElectricBillApi.Models;
using ElectricBillApi.Exceptions;
using System;
using Xunit;
using ElectricBillApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBillApi.Tests
{
    public class ElectricProviderControllerTests
    {
        private readonly ElectricProviderController _controller;

        private readonly IElectricProviderPicker _electricProviderPicker;

        public ElectricProviderControllerTests()
        {
            _electricProviderPicker = new ElectricProviderPicker();

            _controller = new ElectricProviderController(_electricProviderPicker);
        }

        [Fact]
        public void GetBestProvider_GivenValidAddress_ReturnsOk()
        {
            var anyAddress = new Address { Location = new Location(0, 0, 0) };

            var controllerResponse = _controller.GetBestProvider(anyAddress);

            Assert.IsAssignableFrom<OkObjectResult>(controllerResponse);
        }

        [Fact]
        public void SubscribeToPowerPlant_GivenValidProviderAndPowerPlant_ReturnsOk()
        {
            string windProvider = "OnlyWindElectricityProvider";
            var anyPowerPlant = new PowerPlant { Name = "AnyPowerPlant" };

            var controllerResponse = _controller.SubscribeToPowerPlant(windProvider, anyPowerPlant);

            Assert.IsAssignableFrom<OkObjectResult>(controllerResponse);
        }

        [Fact]
        public void SubscribeToPowerPlant_GivenNonExistingProvider_ThrowsNoProviderFoundException()
        {
            string notExistingProvider = "NotExistingProvider";
            var anyPowerPlant = new PowerPlant { Name = "AnyPowerPlant" };

            Action controllerResponse = () => _controller.SubscribeToPowerPlant(notExistingProvider, anyPowerPlant);

            Assert.Throws<NoProviderFoundException>(controllerResponse);
        }
    }
}
