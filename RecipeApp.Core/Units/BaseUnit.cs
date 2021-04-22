namespace RecipeApp.Core.Units
{
    public abstract class BaseUnit
    {
        public abstract string UnitName { get; }

        public abstract double ConvertToMl(double amount);

        public abstract double ConvertToNextBiggerUnit(double amount);

        public abstract double ConvertToNextSmallerUnit(double amount);
    }
}