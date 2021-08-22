using System.Globalization;

namespace RecipeApp.Core
{
    internal class ConvertToCookingUnitsClass : RecipeConverter
    {
        public static string ConvertToCookingUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                ConvertToCookingUnit(index, words);
            }

            return string.Join(" ", words);
        }

        private static void ConvertToCookingUnit(int index, string[] words)
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

        private static int GetClosestCookingUnitIndex(double ml)
        {
            var smallestDifference = double.MaxValue;

            var closestCookingUnitIndex = 2; // 2 is the smallest unit

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
    }
}