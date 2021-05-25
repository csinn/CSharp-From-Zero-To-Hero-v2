using BootCamp.Chapter;
using System;
using System.Globalization;

namespace RecipeApp
{
    public class RecipeConverter
    {
        static readonly double[] multipliers = { 3790, 950, 470, 240, 29.57, 14.79, 4.93 };
        static readonly string[] units = { "gallon", "quart", "pint", "cup", "ounce", "tablespoon", "teaspoon" };

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

        private static string ConvertToSiUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            bool containsCookingUnits = false;

            for (int index = 0; index < words.Length; index++)
            {
                if(StandardiseCookingUnit(index, words))
                {
                    containsCookingUnits = true;
                }
            }

            if (!containsCookingUnits)
            {
                throw new InvalidRecipeException("No cooking units found in recipe file.");
            }
            else
            {
                GlobalSettings.currentLogger.LogMessage(LogLevel.Info, $"Sucessfully converted recipe to SI units.");
            }
            return string.Join(" ", words);
        }

        static bool StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindMultiplier(cookingUnit);
            if (multiplier == -1) return false;

            var amountText = words[index - 1].Trim();

            var isNumber = ParseDouble(amountText, out var amount);

            if (!isNumber)
            {
                throw new InvalidRecipeException($"Trying to convert {amountText}  which is not a number. Please check recipe file.");
            }

            var amountMl = amount * multiplier;

            words[index] = GetSiUnit(amountMl);

            words[index - 1] = GetAmountInSiUnits(amountMl);

            return true;
        }

        private static string GetAmountInSiUnits(double amountMl)
        {
            if (amountMl >= 100)
            {
                amountMl = amountMl / 100;
            }
            return amountMl.ToString("F2", CultureInfo.InvariantCulture);
        }

        private static string GetSiUnit(double amountMl)
        {
            if (amountMl >= 100)
            {
                return "l";
            }
            else
            {
                return "ml";
            }
        }

        static double FindMultiplier(string cookingUnit)
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

        private static string ConvertToCookingUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            bool containsSiUnits = false;

            for (int index = 0; index < words.Length; index++)
            {
                if(StandardiseSiUnit(index, words))
                {
                    containsSiUnits = true;
                }
            }

            if (!containsSiUnits)
            {
                throw new InvalidRecipeException("No SI units found in the recipe file.");
            }
            else
            {
                GlobalSettings.currentLogger.LogMessage(LogLevel.Info, $"Sucessfully converted recipe to cooking units.");
            }

            return string.Join(" ", words);
        }

        private static bool StandardiseSiUnit(int index, string[] words)
        {
            var ml = GetMl(index, words);

            if (ml == -1) return false;

            var cookingUnitIndex = GetClosestCookingUnitIndex(ml);

            var unit = units[cookingUnitIndex];
            var multiplier = multipliers[cookingUnitIndex];
            var convertedAmount = ml / multiplier;

            words[index - 1] = convertedAmount.ToString("F2", CultureInfo.InvariantCulture);
            words[index] = unit;

            return true;
        }

        static double GetMl(int index, string[] words)
        {
            if (words[index] == "ml")
            {
                var isDouble = ParseDouble(words[index - 1], out double ml);
                if (!isDouble) return -1;

                return ml;
            }
            else if (words[index] == "l")
            {
                var isDouble = ParseDouble(words[index - 1], out double liters);
                if (!isDouble) return -1;

                return (liters * 1000);
            }
            else
            {
                return -1;
            }
        }

        static int GetClosestCookingUnitIndex(double ml)
        {
            for (int i = 0; i < multipliers.Length; i++)
            {
                if (ml / multipliers[i] >= 1)
                {
                    return i;
                }
            }

            return 6;
        }

        static bool ParseDouble(string amountText, out double amount)
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