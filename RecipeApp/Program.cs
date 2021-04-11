using System;
using System.Globalization;
using System.IO;

namespace RecipeApp
{
    class Program
    {
        static double[] multipliers = {240, 14.79, 4.93};
        static string[] units = {"cup", "tablespoon", "teaspoon"};

        static void Main(string[] args)
        {
            string ingredients = ReadAllText(@".\Recipe.txt");
            var standardised = StandardiseRecipe(ingredients);

            WriteAllText(".\\Recipe-Converted.txt", standardised);
        }

        static string ReadAllText(string path)
        {
            using (var stream = new StreamReader(path))
            {
                var contents = stream.ReadToEnd();
                return contents;
            }
        }

        static void WriteAllText(string path, string text)
        {
            var stream = new StreamWriter(path);
            stream.Write(text);
            stream.Dispose();
        }



        static string StandardiseRecipe(string recipe)
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
                finally
                {
                    Console.WriteLine("Always happens");
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

            var isNumber = double.TryParse(
                amountText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out double amount);

            if (!isNumber)
            {
                throw new InvalidRecipeException($"{amountText} is not a number.");
            }

            var amountMl = amount * multiplier;

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
