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
            // 1. Read ingredients from a file (recipe.txt) +
            // 2. Output converted recipe to a new file
            // 3. Validate the file - if it's invalid (next to a cooking unit there is no number - throw error)
            // 4. But handle that error by skipping the invalid (not a number)
            // (Debugging)

            // string marked with @ - is a verbatim string
            // basically, it turns off special characters.
            // Relative file path (from current directory where the app is running)
            // . - current directory
            // .. previous directory (directory above)
            string ingredients = ReadAllText(@".\Recipe.txt");
            var standardised = StandardiseRecipe(ingredients);
            // backslash (\) is used to turn off special characters

            WriteAllText(".\\Recipe-Converted.txt", standardised);
            // Backslash at the start of a file name refers to root disk directory.
            // Absolute path- full path to file.
        }

        static string ReadAllText(string path)
        {
            // 000101001010100101010
            // 00010100 10101001 01001000
            // 8 bits = 1 byte
            // byte[] = stream

            // Using statement is the same as calling dispose at the end of it.
            using (var stream = new StreamReader(path))
            {
                var contents = stream.ReadToEnd();
                return contents;
            }
        }

        static void WriteAllText(string path, string text)
        {
            // Stream is an unamanaged resource.
            // It means it needs to be cleaned up manually.
            var stream = new StreamWriter(path);
            stream.Write(text);
            // We clean up manually by calling a dispose method
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
                    // always happens regardless of success or fail
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

            // TryParse always returns bool (whether the thing can be parsed)
            // through out argument we get the actual parsed value.
            // use out keyword when you want to get a second return value from a function.
            // It is always used in tryParse pattern
            var isNumber = double.TryParse(
                amountText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out double amount);

            if (!isNumber)
            {
                // Throw - raise an error
                // Crash the application
                // Don't allow to continue
                // Unless it gets handled.
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
