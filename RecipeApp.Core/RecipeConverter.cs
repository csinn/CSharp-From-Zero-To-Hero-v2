using RecipeApp.Core.Exceptions;
using System;
using System.Globalization;

namespace RecipeApp
{
    public class RecipeConverter
    {
        private static string[] cookingUnits = { "cup", "tablespoon", "teaspoon", "gallon", "pint", "quart", "fluid ounce" };
        private static double[] mlMultipliers = { 240, 14.79, 4.93, 3790, 470, 950, 29.57 };

        public static string ConvertRecipe(string recipe, bool isSiUnit)
        {
            if (isSiUnit)
            {
                return ConvertToSiUnits(recipe);
            }
            else
            {
                return ConvertToCookingUnits(recipe);
            }
        }

        public static string ConvertToSiUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                try
                {
                    StandardiseCookingUnit(index, words);
                }
                catch (InvalidRecipeException ex)
                {
                    Console.WriteLine($"Skipping word, because: {ex.Message}");
                }
            }

            return string.Join(" ", words);
        }

        public static bool ParseDouble(string amountText, out double amount)
        {
            var isNumber = double.TryParse(
                amountText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out amount);

            return isNumber;
        }

        private static void ConvertToCookingUnit(int index, string[] words)
        {
            var ml = GetMl(index, words);
            if (ml == -1) return;

            var cookingUnitIndex = GetClosestCookingUnitIndex(ml);
            var unit = cookingUnits[cookingUnitIndex];
            var multiplier = mlMultipliers[cookingUnitIndex];
            var convertedAmount = ml / multiplier;

            words[index - 1] = convertedAmount.ToString("F2", CultureInfo.InvariantCulture);
            words[index] = unit;
        }

        private static string ConvertToCookingUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                try
                {
                    ConvertToCookingUnit(index, words);
                }
                catch (InvalidRecipeException ex)
                {
                    Console.WriteLine($"Skipping word, because: {ex.Message}");
                }
            }

            return string.Join(" ", words);
        }

        private static double FindMultiplier(string cookingUnit)
        {
            for (int index = 0; index < cookingUnits.Length; index++)
            {
                if (cookingUnits[index].Equals(cookingUnit, StringComparison.OrdinalIgnoreCase) ||
                    (cookingUnits[index] + "s").Equals(cookingUnit, StringComparison.OrdinalIgnoreCase))
                {
                    return mlMultipliers[index];
                }
            }

            return -1;
        }

        private static int GetClosestCookingUnitIndex(double ml)
        {
            var smallestDifference = double.MaxValue;
            // 2 is the smallest multiplier.
            var closestCookingUnitIndex = 2;
            for (int i = 0; i < mlMultipliers.Length; i++)
            {
                var multipler = mlMultipliers[i];
                if (multipler > ml) continue;

                var difference = ml - multipler;
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    closestCookingUnitIndex = i;
                }
            }

            return closestCookingUnitIndex;
        }

        private static double GetMl(int index, string[] words)
        {
            if (words[index] == "ml")
            {
                var isNumber = ParseDouble(words[index - 1], out var ml);
                if (!isNumber) return -1;

                return ml;
            }
            else
            {
                return -1;
            }
        }

        private static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindMultiplier(cookingUnit);
            if (multiplier == -1) return;

            var amountText = words[index - 1].Trim();

            var isNumber = ParseDouble(amountText, out var amount);

            if (!isNumber)
            {
                throw new InvalidRecipeException($"{amountText} is not a number.");
            }

            var amountMl = amount * multiplier;

            if (amountMl > 100)
            {
                words[index] = "l";
                words[index - 1] = (amountMl / 100).ToString("F2", CultureInfo.InvariantCulture);
                return;
            }

            words[index] = "ml";
            words[index - 1] = amountMl.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}