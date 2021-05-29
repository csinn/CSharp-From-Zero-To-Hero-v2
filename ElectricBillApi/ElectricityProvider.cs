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

        public decimal CalculatePrice(Address address)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(PowerPlant plant)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(PowerPlant plant)
        {
            throw new NotImplementedException();
        }
    }
}
