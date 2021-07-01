using ElectricityBillApi.Models;
using System;
using Xunit;

namespace ElectricityBillApi.Tests
{
    public class ElectricProviderTests
    {
        private ElectricProvider _sut;

        public ElectricProviderTests()
        {
            _sut = new ElectricProvider();
        }

        [Fact]
        public void CalculatePrice_CalculatesCorrectPrice()
        {
            // arrange
            var loc1 = new Location(0, 0, 0);
            var loc2 = new Location(1, 1, 1);
            decimal electricityPrice = 5;
            var plant = new PowerPlant()
            {
                Location = loc1,
                ElectricityPrice = electricityPrice
            };

            // act
            _sut.Subscribe(plant);
            var actual = _sut.CalculatePrice(new Address() { Location = loc2 });
            var expected = 3 * electricityPrice;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePrice_ThrowsIfNoPlantIsSubscribed()
        {
            // arrange
            var loc2 = new Location(1, 1, 1);
            var address = new Address() { Location = loc2 };

            // act
            Action priceCalculation = () => _sut.CalculatePrice(address);

            // assert
            Assert.ThrowsAny<ArgumentNullException>(priceCalculation);
        }

        [Fact]
        public void Subscribe_SubscribeTwoTimesThrows()
        {
            // arrange
            var plant = new PowerPlant();
            var plant2 = new PowerPlant();

            // act
            _sut.Subscribe(plant);

            // assert
            Assert.ThrowsAny<InvalidOperationException>(() => _sut.Subscribe(plant2));
        }

        [Fact]
        public void Unsubscribe_SubscribeTwoTimesDoesntThrow()
        {
            // arrange
            var plant = new PowerPlant();

            // act
            _sut.Subscribe(plant);

            // assert
            _sut.Unsubscribe(plant);
            _sut.Unsubscribe(plant);
        }
    }
}