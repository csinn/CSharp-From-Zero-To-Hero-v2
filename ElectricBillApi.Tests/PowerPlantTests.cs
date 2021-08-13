using ElectricBillApi.Models;
using System;
using Xunit;

namespace ElectricBillApi.Tests
{
    public class PowerPlantTests
    {
        [Theory]
        [InlineData("Plant", "Plant", true)]
        [InlineData("Plant", "plant", true)]
        [InlineData("Noname", "Plant", false)]
        public void Equals_WhenComparingTwoPlantsWithSameName_ShouldReturnTrue(string name1, string name2, bool expectedResult)
        {
            var powerPlant1 = new PowerPlant { Name = name1 };
            var powerPlant2 = new PowerPlant { Name = name2 };

            var evaluatedResult = powerPlant1.Equals(powerPlant2);

            Assert.Equal(expectedResult, evaluatedResult);
        }

        [Theory]
        [InlineData("Plant", "Plant", true)]
        [InlineData("Plant", "plant", true)]
        [InlineData("Noname", "Plant", false)]
        public void OperatorEqual_WhenComparingTwoPlantsWithSameNameShouldReturnTrue(string name1, string name2, bool expectedResult)
        {
            var powerPlant1 = new PowerPlant { Name = name1 };
            var powerPlant2 = new PowerPlant { Name = name2 };

            var evaluatedResult = powerPlant1 == powerPlant2;

            Assert.Equal(expectedResult, evaluatedResult);
        }

        [Fact]
        public void Equals_WhenOtherPowerPlantNameIsNull_ThrowsNullReferenceException()
        {
            var powerPlant = new PowerPlant { Name = "MyPowerPlant" };
            var powerPlantWhereNameIsNull = new PowerPlant { Name = null };

            Action equalToNullNamedPowerPlant = () => powerPlant.Equals(powerPlantWhereNameIsNull);

            Assert.Throws<NullReferenceException>(equalToNullNamedPowerPlant);
        }
    }
}
