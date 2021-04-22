using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Core.Units.Cooking
{
    public class FluidOunce : BaseUnit
    {
        public override string UnitName => "fluid ounce";

        public override double ConvertToMl(double amount)
        {
            return amount * 29.57;
        }

        public override double ConvertToNextBiggerUnit(double amount)
        {
            return amount / 8;
        }

        public override double ConvertToNextSmallerUnit(double amount)
        {
            return amount * 2;
        }
    }
}
