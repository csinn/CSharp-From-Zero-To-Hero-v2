using System.Collections.Generic;

namespace RecipeApp.Core.Units
{
    internal static class Conversion
    {
        internal static Dictionary<string, double> CookingUnits = new Dictionary<string, double>
        {
            { "teaspoon", 4.93},
            { "tablespoon", 14.79},
            { "quart", 950},
            { "pint", 470},
            { "gallon", 3790},
            { "fluid ounce", 29.57},
            { "cup", 240}
        };

        internal static Dictionary<string, double> SiUnits = new Dictionary<string, double>
        {
            { "ml", 1},
            { "l", 1000}
        };
    }
}