using ElectricBillApi.Models;
using ElectricBillApi.Services;
using System;
using Xunit;

namespace ElectricBillApi.Tests
{
    public class ElectricityProviderTests
    {
        [Theory]
        [InlineData(40, 30, 2, 1.2)]
        [InlineData(44.99, 30, 2, 1.2)]
        [InlineData(45, 30, 2, 3)]
        [InlineData(50, 30, 2, 6)]
        [InlineData(90, 30, 2, 15)]
        [InlineData(140, 30, 2, 30)]
        [InlineData(1040, 30, 2, 75)]
        public void CalculatePrice_WhenExistingAdress_Returns_PriceFromProvider(double x, double y, double z, decimal expectedPrice)
        {
            var service = new ElectricityProvider();
            Location anyLocation = new Location(x, y, z);
            Address anyAddress = new Address { Location = anyLocation };

            var calculatedPrice = service.CalculatePrice(anyAddress);

            Assert.Equal(expectedPrice, calculatedPrice);
        }

        [Fact]
        public void CalculatePrice_WhenAdressIsNull_ThrowsNullReferenceException()
        {
            var service = new ElectricityProvider();
            Address nullAddress = null;

            Action calculatePriceWhenAdressIsNull = () => service.CalculatePrice(nullAddress);

            Assert.Throws<NullReferenceException>(calculatePriceWhenAdressIsNull);
        }
    }
}
