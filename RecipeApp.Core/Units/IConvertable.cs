namespace RecipeApp.Core.Units
{
    public interface IConvertable
    {
        BaseUnit ConvertTo<T>() where T : BaseUnit, new();
    }
}