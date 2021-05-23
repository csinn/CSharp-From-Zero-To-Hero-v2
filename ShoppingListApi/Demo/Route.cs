using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Demo
{
    public class Route
    {
        public Point[] Path { get; }

        public Route(Point[] path)
        {
            if (path == null) throw new InvalidRouteException();
            if (path.Length < 2) throw new InvalidRouteException(2);
            
            Path = path;
        }

        public double CalculateDistance()
        {
            double totalDistance = 0;

            for (int i = 0; i < Path.Length-1; i++)
            {
                var currentPoint = Path[i];
                var nextPoint = Path[i + 1];
                var distance = currentPoint.DistanceTo(nextPoint);
                totalDistance += distance;
            }

            return totalDistance;
        }
    }

    public class InvalidRouteException : Exception
    {
        public InvalidRouteException() : base("Null points")
        {
        }

        public InvalidRouteException(int pointsCount) : base("A route must have at least 2 points, but was "+ pointsCount)
        {
        }
    }
}
