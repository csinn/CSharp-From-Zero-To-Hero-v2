using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace Demo.Tests
{
    public class PointTests
    {
        [Fact]
        public void ToString_IncludesXandY()
        {
            var point = new Point(1, 2);

            var description = point.ToString();

            const string expected = "X=1, Y=2";
            Assert.Equal(expected, description);
        }

        [Theory]
        [MemberData(nameof(ExpectedDistancesBetweenPoints))]
        public void DistanceTo_WhenTheOtherPointExists_Returns_DistanceBetween2Points(
            Point point1, Point point2, double expectedDistance)
        {
            var distance = point1.DistanceTo(point2);

            const int precision = 2;
            Assert.Equal(expectedDistance, distance, precision);
        }

        [Fact]
        public void Distance_WhenOtherPointIsNull_ThrowsArgumentNullException()
        {
            var anyPoint = new Point(0, 0);
            Point nullPoint = null;

            Action distanceToNullPoint = () => anyPoint.DistanceTo(nullPoint);

            Assert.Throws<ArgumentNullException>(distanceToNullPoint);
        }

        public static IEnumerable<object[]> ExpectedDistancesBetweenPoints
        {
            get
            {
                yield return new object[]
                {
                    new Point(0, 0), 
                    new Point(0, 0), 
                    0
                };

                yield return new object[]
                {
                    new Point(1, 0),
                    new Point(0, 0),
                    1
                };

                yield return new object[]
                {
                    new Point(1, 0),
                    new Point(1, 0),
                    0
                };

                yield return new object[]
                {
                    new Point(3, 4),
                    new Point(0, 0),
                    5
                };

                yield return new object[]
                {
                    new Point(0, 0),
                    new Point(3, 4),
                    5
                };

                yield return new object[]
                {
                    new Point(5, -2),
                    new Point(8, 2),
                    5
                };
            }
        }
    }
}
