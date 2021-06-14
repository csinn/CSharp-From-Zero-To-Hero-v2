using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricBillApi.Models
{
    public class PowerPlant : IComparable
    {
        public Location Location { get; set; }
        public decimal ElectricityPrice { get; set; }
        public double ProducedPowerPerDay { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            var plant = obj as PowerPlant;

            if (plant == null)
            {
                return -1;
            }

            if(Location == plant.Location &&
               ElectricityPrice == plant.ElectricityPrice &&
               ProducedPowerPerDay == plant.ProducedPowerPerDay &&
               Name == plant.Name)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
