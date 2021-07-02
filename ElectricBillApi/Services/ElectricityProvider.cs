using ElectricBillApi.Exceptions;
using ElectricBillApi.Interfaces;
using ElectricBillApi.Models;
using System;
using System.Collections.Generic;

namespace ElectricBillApi.Services
{
    public class ElectricityProvider : IElectricityProvider
    {
        private PowerPlant currentSubscribedPowerPlant = null;
        private readonly IList<Models.Range> _costRange;
        private readonly Random _random = new();

        public string Name { get; set; }
        public string CurrentSubscribedPlant { get => currentSubscribedPowerPlant.Name; }

        public ElectricityProvider()
        {
            // Random cost increasing with distance between adress and powerplants adress.
            _costRange = new List<Models.Range>
            {
                new Models.Range(5, _random.Next(1, 3)),
                new Models.Range(10, _random.Next(4, 6)),
                new Models.Range(50, _random.Next(7, 19)),
                new Models.Range(100, _random.Next(20, 30)),
                new Models.Range(1000, _random.Next(31, 50))
            };

            //For demo purposes. Will be injected if "AddPowerPlant" is added in the api.
            currentSubscribedPowerPlant = new PowerPlant
            {
                Name = "Startup powerplant",
                ElectricityPrice = 0.6M,
                Location = new Location
                {
                    X = 40,
                    Y = 30,
                    Z = 2
                },
                ProducedPowerPerDay = 400000
            };
        }

        public decimal CalculatePrice(Address address)
        {
            if(currentSubscribedPowerPlant == null)
            {
                throw new NoSubscribedPowerPlantException("Cannot calculate cost. No subscription to a Powerplant exists.");
            }

            var distanceFromPlantToCustomer = CalculateDistance(address.Location, currentSubscribedPowerPlant.Location);

            for (int i = 0; i < _costRange.Count; i++)
            {
                var range = _costRange[i];
                
                if((decimal)distanceFromPlantToCustomer < range.End)
                {
                    return range.Cost * currentSubscribedPowerPlant.ElectricityPrice;
                }
            }

            return 15;
        }

        public void Subscribe(PowerPlant plant)
        {
            if(plant.IsPowerPlantValid())
            {
                if(plant.Name == currentSubscribedPowerPlant.Name)
                {
                    throw new AlreadySubscribedException($"Already subscribed to {plant.Name}.");
                }
                else
                {
                    currentSubscribedPowerPlant = plant;
                }
            }
            else
            {
                throw new NoValidPowerPlantException("No valid powerplant was provided. Must have valid name and location.");
            }
        }

        public void Unsubscribe(PowerPlant plant)
        {
            if(currentSubscribedPowerPlant == null || currentSubscribedPowerPlant.Name != plant.Name)
            {
                return;
            }
            else
            {
                currentSubscribedPowerPlant = null;
            }
        }

        private static double CalculateDistance (Location a, Location b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2) + Math.Pow((a.Z - b.Z), 2));
        }
    }
}
