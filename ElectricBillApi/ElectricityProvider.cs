using ElectricBillApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ElectricBillApi
{
    public class ElectricityProvider : IElectricityProvider
    {
        public string Name { get; set; }

        private PowerPlant currentSubscribedPowerPlant = null;

        public decimal CalculatePrice(Address address)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(PowerPlant plant)
        {
            if(plant != null)
            {
                if(plant == currentSubscribedPowerPlant)
                {
                    throw new AlreadySubscribedException(plant.Name);
                }
                else
                {
                    currentSubscribedPowerPlant = plant;
                }
            }
        }

        public void Unsubscribe(PowerPlant plant)
        {
            throw new NotImplementedException();
        }
    }
}
