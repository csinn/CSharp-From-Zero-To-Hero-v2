using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeApp.Core
{
    public class RecipeValidator
    {
        static string[] units = { "cup", "tablespoon", "teaspoon", "gallon", "fluid ounce", "pint", "quart", "ml", "l"};

        public static void ValidateRecipeUnits(string recipe)
        {
            if (string.IsNullOrEmpty(recipe))
            {
                throw new InvalidRecipeException("Recipe is empty");
            }

            var fileContainsCookingOrOtherUnits = IsRecipeContainingCookingUnit(recipe);
            if (!fileContainsCookingOrOtherUnits)
            {
                throw new InvalidRecipeException("Recipe didn't have correct cooking units");
            }
        }

        public static bool IsRecipeContainingCookingUnit(string text)
        {
            string[] splitText = text.Split(' ', '\n');

            for (int i = 0; i < splitText.Length; i++)
            {
                for (int j = 0; j < units.Length; j++)
                {
                    bool textContainsUnit =
                        splitText[i].Equals(units[j], StringComparison.OrdinalIgnoreCase) ||
                        splitText[i].Equals(units[j] + "s", StringComparison.OrdinalIgnoreCase);

                    if (textContainsUnit) return true;
                }
            }

            return false;
        }
    }
}
