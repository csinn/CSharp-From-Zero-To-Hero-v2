using System;

namespace RecipeApp.Core.Units.Cooking
{
    public class Tablespoon : BaseUnit
    {
        public override string UnitName => "tablespoon";

        public override double ConvertToMl(double amount)
        {
            return amount * 14.79;
        }

        public override double ConvertToNextBiggerUnit(double amount)
        {
            return amount / 2;
        }

        public override double ConvertToNextSmallerUnit(double amount)
        {
            return amount * 3;
        }
    }
}