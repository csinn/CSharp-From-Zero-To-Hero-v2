using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ElectricBillApi.Models
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static double CalculateDistance(Location a, Location b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2) + Math.Pow((a.Z - b.Z), 2));
        }
    }

    
}
