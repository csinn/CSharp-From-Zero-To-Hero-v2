using ElectricityBillApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityBillApi.Services
{
    public class ElectricProviderPickerService : IElectricProviderPickerService
    {
        private readonly IElectricProviders _providers;

        public ElectricProviderPickerService(IElectricProviders providers)
        {
            _providers = providers;
        }

        public (ElectricProvider, decimal) FindCheapestProviderAndPrice(Address address)
        {
            decimal smallestPrice = decimal.MaxValue;

            foreach (var provider in _providers.GetProviders)
            {
                decimal currentPrice = provider.CalculatePrice(address);
                if (currentPrice < smallestPrice)
                {
                    smallestPrice = currentPrice;
                }
            }

            var cheapestProvider = _providers.GetProviders.First(p => p.CalculatePrice(address) == smallestPrice);

            return (cheapestProvider, smallestPrice);
        }
    }
}