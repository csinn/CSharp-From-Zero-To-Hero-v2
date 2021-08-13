using System;

namespace ElectricBillApi.Models
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

        public double CalculateDistanceTo(Location other)
        {
            return Math.Sqrt(
                Math.Pow((X - other.X), 2) + 
                Math.Pow((Y - other.Y), 2) + 
                Math.Pow((Z - other.Z), 2));
        }
    }
}
