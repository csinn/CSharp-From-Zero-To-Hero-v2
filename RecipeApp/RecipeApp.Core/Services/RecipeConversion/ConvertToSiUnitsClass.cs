using System.Globalization;

namespace RecipeApp.Core
{
    internal class ConvertToSiUnitsClass : RecipeConverter
    {
        public static string ConvertToSiUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                StandardiseCookingUnit(index, words);
            }

            return string.Join(" ", words);
        }

        private static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindMultiplier(cookingUnit);
            if (multiplier == -1) return;

            var amountText = words[index - 1].Trim();

            var isNumber = double.TryParse(amountText, NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out double amount);

            if (!isNumber)
            {
                throw new InvalidRecipeException($"{amountText} is not a number.");
            }

            var amountMl = amount * multiplier;

            if (amountMl > 99)
            {
                amountMl = amountMl / 1000; // will covnert to l
                words[index] = "l";
                words[index - 1] = amountMl.ToString();
            }
            else
            {
                words[index] = "ml";
                words[index - 1] = amountMl.ToString();
            }
        }
    }
}