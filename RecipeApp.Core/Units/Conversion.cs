﻿using System.Collections.Generic;

namespace RecipeApp.Core.Units
{
    internal static class Conversion
    {
        internal static Dictionary<string, double> ToMl = new Dictionary<string, double>
        {
            { "teaspoon", 4.93},
            { "tablespoon", 14.79},
            { "quart", 950},
            { "pint", 470},
            { "gallon", 3790},
            { "fluid ounce", 29.57},
            { "fluid ounce", 29.57},
            { "milliliter", 1},
            { "liter", 1000},
            { "cup", 240}
        };
    }
}