namespace RecipeApp.Core.Units.Cooking
{
    public class Teaspoon : BaseUnit
    {
        public override string UnitName => "teaspoon";

        public override double ConvertToMl(double amount)
        {
            return amount * 4.93;
        }

        public override double ConvertToNextBiggerUnit(double amount)
        {
            return amount / 3;
        }

        public override double ConvertToNextSmallerUnit(double amount)
        {
            return amount;
        }
    }
}