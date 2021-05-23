using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class RouteTests
    {
        [Fact]
        public void NewRoute_StartsWithMultiplePoints()
        {
            var routePoint1 = new Point(0, 0);
            var routePoint2 = new Point(0, 1);
            var routePoints = new []{routePoint1, routePoint2};

            var route = new Route(routePoints);

            Assert.Contains(routePoint1, route.Path);
            Assert.Contains(routePoint2, route.Path);
        }

        [Theory]
        [MemberData(nameof(InvalidRoutes))]
        public void NewRoute_WhenLessThan2PointsOrNull_ThrowsInvalidRouteException(Point[] routePoints)
        {
            Action newRoute = () => new Route(routePoints);

            Assert.Throws<InvalidRouteException>(newRoute);
        }

        [Theory]
        [MemberData(nameof(ExpectedPathDistances))]
        public void CalculateDistance_ReturnsASumOfDistancesBetweenAdjacentPoints(Point[] routePoints, double expectedDistance)
        {
            var route = new Route(routePoints);

            var distance = route.CalculateDistance();

            const int precision = 2;
            Assert.Equal(expectedDistance, distance, precision);
        }

        public static IEnumerable<object[]> InvalidRoutes
        {
            get
            {
                yield return new object[] { null };
                yield return new object[] { new Point[0] };
                yield return new object[] { new [] { new Point(0, 0) }};
            }
        }

        public static IEnumerable<object[]> ExpectedPathDistances
        {
            get
            {
                yield return new object[]
                {
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                    },
                    1
                };

                yield return new object[]
                {
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(0, 0),
                    },
                    2
                };
            }
        }
    }
}
