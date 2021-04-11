using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace RecipeApp
{
    public class RecipeConverter
    {
        static double[] multipliers = {240, 14.79, 4.93};
        static string[] units = {"cup", "tablespoon", "teaspoon"};

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

        private static string ConvertToCookingUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');
            for (int index = 0; index < words.Length; index = index + 1)
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

        private static string ConvertToSiUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index = index + 1)
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

        static void StandardiseCookingUnit(int index, string[] words)
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

            words[index] = "ml";
            words[index - 1] = amountMl.ToString("F2", CultureInfo.InvariantCulture);
        }

        static double FindMultiplier(string cookingUnit)
        {
            for (int index = 0; index < units.Length; index++)
            {
                if (units[index].Equals(cookingUnit, StringComparison.OrdinalIgnoreCase) || 
                    (units[index]+"s").Equals(cookingUnit, StringComparison.OrdinalIgnoreCase))
                {
                    return multipliers[index];
                }
            }

            return -1;
        }

        static void ConvertToCookingUnit(int index, string[] words)
        {
            var ml = GetMl(index, words);
            if (ml == -1) return;

            var cookingUnitIndex = GetClosestCookingUnitIndex(ml);
            var unit = units[cookingUnitIndex];
            var multiplier = multipliers[cookingUnitIndex];
            var convertedAmount = ml / multiplier;

            words[index - 1] = convertedAmount.ToString("F2", CultureInfo.InvariantCulture);
            words[index] = unit;
        }

        static double GetMl(int index, string[] words)
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

        static int GetClosestCookingUnitIndex(double ml)
        {
            var smallestDifference = double.MaxValue;
            // 2 is the smallest multiplier.
            var closestCookingUnitIndex = 2;
            for (int i = 0; i < multipliers.Length; i++)
            {
                var multipler = multipliers[i];
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

        private static bool ParseDouble(string amountText, out double amount)
        {
            var isNumber = double.TryParse(
                amountText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out amount);

            return isNumber;
        }
    }
}
