namespace RecipeApp.Core.Units
{
    public interface IUnitRepository
    {
        Unit GetClosestCookingUnit(Unit siUnit);
        Unit GetClosestSiUnit(Unit cookingUnit);
        bool TryFindMlCoefficient(Unit unitToConvert, out double coefficient);
        bool TryFindUnit(string unitText, out Unit unit);
    }
}