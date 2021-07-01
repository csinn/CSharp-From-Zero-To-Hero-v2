using System.Collections.Generic;

namespace ElectricityBillApi.Models
{
    public class ElectricProviders : IElectricProviders
    {
        private List<ElectricProvider> _providers = new List<ElectricProvider>();

        public ElectricProviders()
        {
            AddDummyData();
        }

        private void AddDummyData()
        {
            var plant1 = new PowerPlant()
            {
                Name = "Plant1",
                ElectricityPrice = 3m,
                ProducedPowerPerDay = 1000,
                Location = new Location(5,10,11)
            };

            var provider1 = new ElectricProvider()
            {
                Name = "Provider1"
            };
            provider1.Subscribe(plant1);

            var plant2 = new PowerPlant()
            {
                Name = "Plant2",
                ElectricityPrice = 5m,
                ProducedPowerPerDay = 1000,
                Location = new Location(10,5,22)
            };

            var provider2 = new ElectricProvider()
            {
                Name = "Provider2"
            };
            provider2.Subscribe(plant2);

            _providers.Add(provider1);
            _providers.Add(provider2);

        }

        public List<ElectricProvider> GetProviders => _providers;
    }
}