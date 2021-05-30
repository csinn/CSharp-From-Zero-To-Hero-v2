using ElectricityBillApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityBillApi.Services
{
    public class ElectricProviderPickerService : IElectricProviderPickerService
    {
        private readonly ElectricProviders _providers;

        public ElectricProviderPickerService(ElectricProviders providers)
        {
            _providers = providers;
        }

        public ElectricProvider FindCheapest(Address address)
        {
            decimal smallestPrice = decimal.MaxValue;

            foreach (var provider in _providers)
            {
                decimal currentPrice = provider.CalculatePrice(address);
                if (currentPrice < smallestPrice)
                {
                    smallestPrice = currentPrice;
                }
            }

            return _providers.First(p => p.CalculatePrice(address) == smallestPrice);
        }
    }
}