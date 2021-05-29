using ElectricBillApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricBillApi
{
    public interface IElectricityProvider
    {
        void Subscribe(PowerPlant plant);
        void Unsubscribe(PowerPlant plant);
        decimal CalculatePrice(Address address);
    }
}
