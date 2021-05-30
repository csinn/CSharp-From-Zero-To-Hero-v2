using System.Collections.Generic;

namespace ElectricityBillApi.Models
{
    public class ElectricProviders : List<ElectricProvider>
    {
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
                Location = new Location()
                {
                    X = 5,
                    Y = 10,
                    Z = 11
                }
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
                Location = new Location()
                {
                    X = 10,
                    Y = 5,
                    Z = 22
                }
            };

            var provider2 = new ElectricProvider()
            {
                Name = "Provider2"
            };
            provider2.Subscribe(plant2);

            Add(provider1);
            Add(provider2);

        }
    }
}