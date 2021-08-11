using System;
using System.Globalization;
using System.Linq;

namespace RecipeApp.Core
{
    public class RecipeConverter
    {
        protected static double[] multipliers = {240, 14.79, 4.93, 470, 950, 29.57, 3790};
        protected static string[] units = {"cup", "tablespoon", "teaspoon", "Pint", "Quart", "Fluid Ounce", "Gallon"};

        public static string CallConversion(string input, bool isConvertToSiUnit)
        {
            string result;

            if (isConvertToSiUnit)
            {
                result = ConvertToSiUnitsClass.ConvertToSiUnits(input);
            }
            else
            {
                result = ConvertToCookingUnitsClass.ConvertToCookingUnits(input);
            }

            return result;
        }

        protected static double GetMl(int index, string[] words)
        {
            if (words[index] == "ml")
            {
                var IsNumber = double.TryParse(words[index - 1], out var ml);
                if (!IsNumber) return -1;

                return ml;
            }

            if (words[index] == "l")
            {
                var IsNumber = double.TryParse(words[index - 1], out var l);
                if (!IsNumber) return -1;
                var ml = l * 1000;
                return ml;
            }

            return -1;
        }

        protected static double FindMultiplier(string cookingUnit)
        {
            for (int index = 0; index < units.Length; index++)
            {
                if (units[index].Equals(cookingUnit, StringComparison.OrdinalIgnoreCase) ||
                    (units[index] + "s").Equals(cookingUnit, StringComparison.OrdinalIgnoreCase))
                {
                    return multipliers[index];
                }
            }

            return -1;
        }

        public static bool ValidateRecipe(string recipe, bool isConvertToSiUnit)
        {
            if (string.IsNullOrEmpty(recipe)) // if is emptty
            {
                throw new NoNonRecipeFilesException("Input is null or empty");
            }

            if (!recipe.Any(char.IsDigit)) // if doesnt contain any numbers
            {
                throw new NoNonRecipeFilesException("Recipe doesn't contain any digits");
            }

            if (!ContainsCookingUnits(recipe, isConvertToSiUnit)) // if doesnt contain any cooking or volume units
            {
                throw new NoNonRecipeFilesException("Recipe doesn't contain any cooking or volume units");
            }

            if (!AllDigitsAreValid(recipe)) // will throw exception if digits cant be parsed example: 32x, 4a
            {
                // will throw exception in function itself with the digit/word that thrown the exception
                return false;
            }

            return true;
        }

        private static bool ContainsCookingUnits(string recipe, bool isConvertToSiUnit)
        {
            string[] words = recipe.Split(' ', '\n');

            if (isConvertToSiUnit)
            {
                foreach (var word in words)
                {
                    foreach (var unit in units)
                    {
                        if (unit == word || unit + "s" == word)
                        {
                            return true;
                        }
                    }
                }

                throw new NoNonRecipeFilesException("Recipe doesn't contain any cooking units");
            }

            foreach (var word in words)
            {
                if (word == "ml" || word == "l")
                {
                    return true;
                }
            }

            throw new NoNonRecipeFilesException("Recipe doesn't contain any volume units");
        }

        private static bool AllDigitsAreValid(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "ml" || words[i] == "l")
                {
                    var amountText = words[i - 1].Trim();

                    var isNumber = double.TryParse(amountText, NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out double amount);

                    if (!isNumber)
                    {
                        throw new InvalidRecipeException($"{amountText} is not a number.");
                    }
                }

                foreach (var unit in units)
                {
                    if (unit == words[i] || unit + "s" == words[i])
                    {
                        var amountText = words[i - 1].Trim();

                        var isNumber = double.TryParse(amountText, NumberStyles.AllowDecimalPoint,
                            CultureInfo.InvariantCulture, out double amount);

                        if (!isNumber)
                        {
                            throw new InvalidRecipeException($"{amountText} is not a number.");
                        }
                    }
                }
            }

            return true;
        }
    }
}