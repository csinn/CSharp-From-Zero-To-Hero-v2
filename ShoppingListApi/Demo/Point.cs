using System;

namespace Demo
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Math.Sqrt(
                Math.Pow(X-other.X, 2) + 
                Math.Pow(Y-other.Y, 2));
        }

        public override string ToString()
        {
            return $"X={X}, Y={Y}";
        }
    }
}