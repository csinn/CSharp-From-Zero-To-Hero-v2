using ElectricBillApi.Exceptions;
using ElectricBillApi.Interfaces;
using ElectricBillApi.Models;
using System.Collections.Generic;

namespace ElectricBillApi.Services
{
    public class ElectricityProvider : IElectricityProvider
    {
        private PowerPlant currentSubscribedPowerPlant = null;
        private readonly IList<Models.Range> _costRange;

        public string Name { get; set; }
        public string CurrentSubscribedPlant { get => currentSubscribedPowerPlant.Name; }

        public ElectricityProvider()
        {
            // Random cost increasing with distance between adress and powerplants adress.
            _costRange = new List<Models.Range>
            {
                new Models.Range(5, 2),
                new Models.Range(10, 5),
                new Models.Range(50, 10),
                new Models.Range(100, 25),
                new Models.Range(1000, 50)
            };

            //For demo purposes. Will be injected if "AddPowerPlant" is added in the api.
            currentSubscribedPowerPlant = new PowerPlant
            {
                Name = "Startup powerplant",
                ElectricityPrice = 0.6M,
                Location = new Location (40, 30, 2),
                ProducedPowerPerDay = 400000
            };
        }

        public decimal CalculatePrice(Address address)
        {
            var distanceFromPlantToCustomer = address.Location.CalculateDistanceTo(currentSubscribedPowerPlant.Location);

            for (int i = 0; i < _costRange.Count; i++)
            {
                var range = _costRange[i];
                
                if((decimal)distanceFromPlantToCustomer < range.End)
                {
                    return range.Cost * currentSubscribedPowerPlant.ElectricityPrice;
                }
            }

            return 75;
        }

        public void Subscribe(PowerPlant plant)
        {
            if (plant.Equals(currentSubscribedPowerPlant))
            {
                throw new AlreadySubscribedException($"Already subscribed to {plant.Name}.");
            }

            currentSubscribedPowerPlant = plant;
        }

        public void Unsubscribe(PowerPlant plant)
        {
            if(currentSubscribedPowerPlant == null || currentSubscribedPowerPlant.Name != plant.Name)
            {
                return;
            }

            currentSubscribedPowerPlant = null;
        }
    }
}
