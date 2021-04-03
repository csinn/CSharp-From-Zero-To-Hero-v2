using System;
using System.Globalization;

namespace RecipeApp
{
    class Program
    {
        // Here is a list of standard cooking units:
        // Cup	0.24 l
        // Tablespoon  14.79 ml
        // Teaspoon    4.93 ml

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
            // Split(" ") - splits text by an empty space into words
            // Words are stored into words array.
            // array symbol is []
            // string[] is an array of string
            string[] words = recipe.Split(" ");

            // a for loop has:
            // a beginning (int index= 0);
            // an end (index < words.Length)
            // a change (index = index + 1)
            // repeatable code
            for (int index = 0; index < words.Length; index = index + 1)
            {
                StandardiseCookingUnit(index, words);
            }

            // string.Join - combine parts of string into one string
            return string.Join(" ", words);
        }

        static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            // then find the equivalent ml multiplier for that amount
            var multiplier = FindMultiplier(cookingUnit);
            if (multiplier == -1) return;

            // if it is, go back 1 word to find the amount
            var amountText = words[index - 1];

            // multiply the amount from multiplier
            // Culture invariant allows parsing numbers which has a "." as a number decimal places separator.
            var amountMl = double.Parse(amountText, CultureInfo.InvariantCulture) * multiplier;
            // replace the old amount with the new amount
            words[index] = "ml";
            // replace the old unit with the new unit
            words[index - 1] = amountMl.ToString();
        }

        static double FindMultiplier(string cookingUnit)
        {
            for (int index = 0; index < units.Length; index++)
            {
                // || - or
                // When you want to compare whether the strings are equal
                // ignoring their casing
                // use .Equals with StringComparison.OrdinalIgnoreCase.
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
