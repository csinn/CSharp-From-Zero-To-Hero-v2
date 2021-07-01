using ElectricityBillApi.Models;
using ElectricityBillApi.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElectricityBillApi.Tests
{
    public class ElectricProviderPickerServiceTests
    {
        private readonly IElectricProviders _iProviders;
        private readonly List<ElectricProvider> _providers;

        public ElectricProviderPickerServiceTests()
        {
            _providers = GetTestData().ToList();
            _iProviders = Substitute.For<IElectricProviders>();
            _iProviders.GetProviders.ReturnsForAnyArgs(_providers);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_returnsFarCheapestProvider()
        {
            // arrange
            var sut = new ElectricProviderPickerService(_iProviders);
            var ownAddress = new Address()
            {
                Location = new Location(20, 20, 0)
            };

            // act
            var (cheapestProvider, calculatedPrice) = sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.Equal(_providers[1], cheapestProvider);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_returnsNearCheapestProvider()
        {
            // arrange
            var sut = new ElectricProviderPickerService(_iProviders);
            var ownAddress = new Address()
            {
                Location = new Location(0, 0, 0)
            };

            // act
            var (cheapestProvider, calculatedPrice) = sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.Equal(_providers.First(), cheapestProvider);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_throwsIfLocationIsNull()
        {
            // arrange
            var sut = new ElectricProviderPickerService(_iProviders);
            var ownAddress = new Address();

            // act
            Action throwingMethod = () => sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.ThrowsAny<NullReferenceException>(throwingMethod);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_throwsIfNoProvidersExist()
        {
            // arrange
            _iProviders.GetProviders.ReturnsForAnyArgs(new List<ElectricProvider>());
            var sut = new ElectricProviderPickerService(_iProviders);
            var ownAddress = new Address()
            {
                Location = new Location(20, 20, 0)
            };

            // act
            Action throwingMethod = () => sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.ThrowsAny<InvalidOperationException>(throwingMethod);
        }

        private List<ElectricProvider> GetTestData()
        {
            var locationFar = new Location(10, 10, 0);
            var locationNear = new Location(5, 5, 0);

            var providerCheapNear = new ElectricProvider()
            {
                Name = "ProviderCheapNear"
            };
            var providerCheapFar = new ElectricProvider()
            {
                Name = "ProviderCheapFar"
            };
            var providerExpensiveNear = new ElectricProvider()
            {
                Name = "ProviderExpensiveNear"
            };
            var providerExpensiveFar = new ElectricProvider()
            {
                Name = "ProviderExpensiveFar"
            };

            var plantCheap = new PowerPlant()
            {
                ElectricityPrice = 2.50m,
                Location = locationNear
            };
            var plantExpensive = new PowerPlant()
            {
                ElectricityPrice = 250m,
                Location = locationNear
            };
            var plantCheapFar = new PowerPlant()
            {
                ElectricityPrice = 2.50m,
                Location = locationFar
            };
            var plantExpensiveFar = new PowerPlant()
            {
                ElectricityPrice = 250m,
                Location = locationFar
            };

            providerCheapNear.Subscribe(plantCheap);
            providerCheapFar.Subscribe(plantCheapFar);
            providerExpensiveNear.Subscribe(plantExpensive);
            providerExpensiveFar.Subscribe(plantExpensiveFar);

            return new List<ElectricProvider>() 
            {
                providerCheapNear,
                providerCheapFar,
                providerExpensiveNear,
                providerExpensiveFar
            };
        }
    }
}