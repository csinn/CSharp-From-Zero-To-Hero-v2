using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillApi.Models
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Location(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
