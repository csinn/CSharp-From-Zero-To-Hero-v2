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
        [Fact]
        public void FindCheapestProviderAndPrice_returnsNearCheapestProvider()
        {
            // arrange
            var providers = GetTestData().ToList();
            var iProviders = Substitute.For<IElectricProviders>();
            iProviders.GetProviders.ReturnsForAnyArgs(providers);
            var sut = new ElectricProviderPickerService(iProviders);
            var ownAddress = new Address()
            {
                Location = new Location()
                {
                    X=0,
                    Y=0,
                    Z=0
                }
            };

            // act 
            var (cheapestProvider, calculatedPrice) = sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.Equal(providers.First(), cheapestProvider);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_returnsFarCheapestProvider()
        {
            // arrange
            var providers = GetTestData().ToList();
            var iProviders = Substitute.For<IElectricProviders>();
            iProviders.GetProviders.ReturnsForAnyArgs(providers);
            var sut = new ElectricProviderPickerService(iProviders);
            var ownAddress = new Address()
            {
                Location = new Location()
                {
                    X=20,
                    Y=20,
                    Z=0
                }
            };

            // act 
            var (cheapestProvider, calculatedPrice) = sut.FindCheapestProviderAndPrice(ownAddress);

            // assert
            Assert.Equal(providers[1], cheapestProvider);
        }

        [Fact]
        public void FindCheapestProviderAndPrice_throwsIfNoProvidersExist()
        {
            // arrange
            var iProviders = Substitute.For<IElectricProviders>();
            iProviders.GetProviders.ReturnsForAnyArgs(new List<ElectricProvider>());
            var sut = new ElectricProviderPickerService(iProviders);
            var ownAddress = new Address()
            {
                Location = new Location()
                {
                    X = 20,
                    Y = 20,
                    Z = 0
                }
            };

            // act 

            // assert
            Assert.ThrowsAny<InvalidOperationException>(() => sut.FindCheapestProviderAndPrice(ownAddress));
        }

        [Fact]
        public void FindCheapestProviderAndPrice_throwsIfLocationIsNull()
        {
            // arrange
            var providers = GetTestData().ToList();
            var iProviders = Substitute.For<IElectricProviders>();
            iProviders.GetProviders.ReturnsForAnyArgs(providers);
            var sut = new ElectricProviderPickerService(iProviders);
            var ownAddress = new Address();

            // act 

            // assert
            Assert.ThrowsAny<NullReferenceException>(() => sut.FindCheapestProviderAndPrice(ownAddress));
        }

        private IEnumerable<ElectricProvider> GetTestData()
        {
            var locationFar = new Location()
            {
                X = 10,
                Y = 10,
                Z = 0
            };
            var locationNear = new Location()
            {
                X = 5,
                Y = 5,
                Z = 0
            };

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

            yield return providerCheapNear;
            yield return providerCheapFar;
            yield return providerExpensiveNear;
            yield return providerExpensiveFar;
        }
    }
}