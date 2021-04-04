using System;
using System.Globalization;

namespace RecipeApp
{
    class Program
    {
        static double[] multipliers = {240, 14.79, 4.93};
        static string[] units = {"cup", "tablespoon", "teaspoon"};

        static void Main(string[] args)
        {
            string ingredients = "1.5 cups all-purpose flour. 3.5 teaspoons baking powder. " +
                                 "1 teaspoon salt. 1 tablespoon white sugar. 1.25 cups milk. " +
                                 "1 egg. 3 tablespoons butter, melted";

            var standardised = StandardiseRecipe(ingredients);
            Console.WriteLine(standardised);
        }

        static string StandardiseRecipe(string recipe)
        {
            string[] words = recipe.Split(" ");

            for (int index = 0; index < words.Length; index = index + 1)
            {
                StandardiseCookingUnit(index, words);
            }

            return string.Join(" ", words);
        }

        static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindMultiplier(cookingUnit);
            if (multiplier == -1) return;

            var amountText = words[index - 1];

            var amountMl = double.Parse(amountText, CultureInfo.InvariantCulture) * multiplier;
            words[index] = "ml";
            words[index - 1] = amountMl.ToString();
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
    }
}
