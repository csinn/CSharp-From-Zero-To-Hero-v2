﻿using RecipeApp.Core.Exceptions;
using RecipeApp.Core.Units;
using System;
using System.Globalization;

namespace RecipeApp
{
    public class RecipeConverter
    {
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

        internal static double FindSiMultiplier(string cookingUnit)
        {
            foreach (var unit in Conversion.CookingUnits)
            {
                if (unit.Key.Equals(cookingUnit, StringComparison.OrdinalIgnoreCase) ||
                    (unit.Key + "s").Equals(cookingUnit, StringComparison.OrdinalIgnoreCase))
                {
                    return unit.Value;
                }
            }

            return -1;
        }

        internal static bool ParseDouble(string amountText, out double amount)
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
            var ml = GetSiUnit(index, words);
            if (ml == -1) return;

            var cookingUnit = GetClosestCookingUnit(ml);
            var multiplier = Conversion.CookingUnits[cookingUnit];
            var convertedAmount = ml / multiplier;

            words[index - 1] = convertedAmount.ToString("F2", CultureInfo.InvariantCulture);
            words[index] = cookingUnit;
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

        private static string GetClosestCookingUnit(double ml)
        {
            var smallestConversion = double.MaxValue;
            // 2 is the smallest multiplier.
            var closestCookingUnit = "cup";

            foreach (var unit in Conversion.CookingUnits)
            {
                var coefficient = unit.Value;

                if (coefficient > ml) continue;

                var conversion = ml / coefficient;
                if (conversion < smallestConversion)
                {
                    smallestConversion = conversion;
                    closestCookingUnit = unit.Key;
                }
            }

            return closestCookingUnit;
        }

        private static double GetSiUnit(int index, string[] words)
        {
            if (words[index] == "ml" || words[index] == "l")
            {
                var isNumber = ParseDouble(words[index - 1], out var siAmount);
                if (!isNumber) return -1;

                return siAmount;
            }
            else
            {
                return -1;
            }
        }

        private static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindSiMultiplier(cookingUnit);
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