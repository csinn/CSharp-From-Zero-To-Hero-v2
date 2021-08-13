using ElectricBillApi.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ElectricBillApi.Tests
{
    public class LocationTests
    {
        public static IEnumerable<object[]> ExpectedDistanceBetweenLocations
        {
            get
            {
                yield return new object[]
                {
                    new Location(0, 0, 0),
                    new Location(0, 0, 0),
                    0
                };

                yield return new object[]
                {
                    new Location(1, -1, 3),
                    new Location(4, 2, -1),
                    5.831
                };
            }
        }

        [Theory]
        [MemberData(nameof(ExpectedDistanceBetweenLocations))]
        public void CalculateDistanceTo_WhenOtherLocationExits_Returns_DistanceBetweenTwoLocations(
            Location location1, Location location2, double expectedDistance)
        {
            var distance = location1.CalculateDistanceTo(location2);

            const int precision = 3;
            Assert.Equal(expectedDistance, distance, precision);
        }

        [Fact]
        public void CalculateDistanceTo_WhenOtherLocationIsNull_ThrowsNullReferenceException()
        {
            var location = new Location(1, 1, 1);
            Location nullLocation = null;

            Action distanceToNullLocation = () => location.CalculateDistanceTo(nullLocation);

            Assert.Throws<NullReferenceException>(distanceToNullLocation);
        }
    }
}
