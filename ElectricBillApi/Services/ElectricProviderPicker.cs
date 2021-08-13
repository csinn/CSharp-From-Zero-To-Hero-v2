using ElectricBillApi.Interfaces;
using ElectricBillApi.Models;
using System.Collections.Generic;

namespace ElectricBillApi.Services
{
    public class ElectricProviderPicker : IElectricProviderPicker
    {
        // This is only for demo purposes. Will be injected when/if adding provider should be done in the api.
        private static readonly List<ElectricityProvider> electricityProviders = new()
        {
            new ElectricityProvider { Name = "GreenElectricityProvider" },
            new ElectricityProvider { Name = "TradElectricityProvider" },
            new ElectricityProvider { Name = "OnlyWindElectricityProvider" },
            new ElectricityProvider { Name = "NukedElectricityProvider" }
        };

        public static List<ElectricityProvider> ElectricityProviders { get => electricityProviders; }

        public ElectricityProvider FindCheapest (Address adress)
        {
            if (adress == null || adress.Location == null)
            {
                return null;
            }

            ElectricityProvider cheapestProvider = null;

            decimal lowestCost = 0;

            foreach (var provider in ElectricityProviders)
            {
                var priceFromProvider = provider.CalculatePrice(adress);

                if(lowestCost == 0)
                {
                    lowestCost = priceFromProvider;
                    cheapestProvider = provider;
                }
                else
                {
                    if (priceFromProvider < lowestCost)
                    {
                        lowestCost = priceFromProvider;
                        cheapestProvider = provider;
                    }
                }
            }

            return cheapestProvider;
        }
    }
}
