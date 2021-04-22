using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;

namespace RecipeApp
{
    public class RecipeConverter
    {
        static double[] multipliers = {240,3790,29.57,470,950,14.79,4.93};
        static string[] units = {"cup","gallon","fluid ounce","pint","quart","tablespoon","teaspoon"};
        static List<string> doubleUnits = new List<string>();

        // Entry method to get some initial setup for Lists
        public static void InitialSetup() {
            PopulateDoubleUnitsList();
            SortCookingUnitsByMultiplier();
        }

        public static string RecipeValidation(string recipeText) {
            if (recipeText.Length == 0)
            {
                return "Empty recipes are not allowed.";
            }
            else if (!recipeText.Any(char.IsDigit))
            {
                return "Recipe does not contain any numeric values.";
            }
            else if (!RecipeConverter.DoesContainCookingUnits(recipeText))
            {
                return "Recipe does not contain any cooking units";
            }
            else if (RecipeConverter.ReturnFirstFaultyCookingUnitIndex(recipeText) != -1)
            {
                return "Bad or non-existant cooking unit values detected.";
            }
            return "";
        }

        // Sort cooking units by multiplier
        static void SortCookingUnitsByMultiplier() {
            bool sorted = true;
            for (int j = 0; j < multipliers.Length; j++)
            {
                for (int i = 0; i < multipliers.Length - 1; i++)
                {
                    if (multipliers[i]>multipliers[i+1])
                    {
                        //swapping multipliers
                        double temp = multipliers[i];
                        multipliers[i] = multipliers[i + 1];
                        multipliers[i + 1] = temp;
                        //swapping units
                        string strTemp = units[i];
                        units[i] = units[i + 1];
                        units[i + 1] = strTemp;

                        sorted = false;
                    }
                }
                if (sorted)
                {
                    return;
                }
            }
        }

        // Validation method to check if string contains any of the cooking units
        public static bool DoesContainCookingUnits(string textToCheck) {
            bool containsUnits = false;
            List<string> wordList = new List<string>(textToCheck.ToLower().Split(' ', '\n'));
            for (int i = 0; i < units.Length; i++)
            {
                if (wordList.Contains(units[i]))
                {
                    containsUnits = true;
                }
            }
            if (wordList.Contains("ml") || wordList.Contains("l"))
            {
                containsUnits = true;
            }
            return containsUnits;
        }

        // Check method to ensure that each unit as some value number before it
        // returns -1 if ok, else returns index of bad cooking unit
        public static int ReturnFirstFaultyCookingUnitIndex(string textToCheck) {
            List<string> words = new List<string>(textToCheck.ToLower().Split(' ', '\n'));
            textToCheck = FixDoubleWordedCookingUnits(textToCheck);
            
            // looking for cooking units
            for (int i = 0; i < units.Length; i++)
            {
                string lookFor = units[i].Replace(" ", "_").ToLower();
                int foundUnitIndex = words.FindIndex(x => x.Contains(lookFor));
                if (foundUnitIndex != -1)
                {
                    if (foundUnitIndex != 0)
                    {
                        if (!ParseDouble(words[foundUnitIndex - 1], out var digitAmount))
                        {
                            return foundUnitIndex;
                        }
                        else {
                            words.RemoveRange(foundUnitIndex - 1, 2);
                            i--;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    continue;
                }
            }

            // looking for SI units ml/l
            string[] siUnits = new string[] { "ml", "l" }; 
            for (int i = 0; i < siUnits.Length; i++)
            {
                int foundMlIndex = words.FindIndex(x => x == siUnits[i]);
                while (foundMlIndex != -1)
                {
                    if (foundMlIndex != 0)
                    {
                        if (!ParseDouble(words[foundMlIndex - 1], out var digitAmount))
                        {
                            return foundMlIndex;
                        }
                        else
                        {
                            words.RemoveRange(foundMlIndex - 1, 2);
                            foundMlIndex = words.FindIndex(x => x == siUnits[i]);
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }

        // Find and "fix" units like "fluid ounce" to "fluid_ounce" for easier validation and editing
        public static string FixDoubleWordedCookingUnits(string textToFix) {
            string fixedText = textToFix.ToLower();

            for (int i = 0; i < doubleUnits.Count; i++)
            {
                string replaceWith = doubleUnits[i].ToLower().Replace(" ", "_");
                fixedText = fixedText.Replace(doubleUnits[i], replaceWith);
            }

            return fixedText;
        }

        // Populate double worded unit List
        public static void PopulateDoubleUnitsList() {
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Contains(" "))
                {
                    doubleUnits.Add(units[i]);
                }
            }
        }

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
            words = MultiplyCookingUnits(words);
            return string.Join(" ", words);
        }

        // Multiple cooking units to proper units 3 teaspoons to 1 tablespoon;
        static string[] MultiplyCookingUnits(string[] wordArray) {
            for (int i = 0; i < wordArray.Length; i++)
            {
                var cookingUnit = wordArray[i];
                var multiplier = FindMultiplier(cookingUnit);
                if (multiplier == -1) continue;

                var amountText = wordArray[i - 1].Trim();
                var isNumber = ParseDouble(amountText, out var amount);

                var amountMl = amount * multiplier;
                var cookingUnitIndex = GetClosestCookingUnitIndex(amountMl);
                var unit = units[cookingUnitIndex];
                multiplier = multipliers[cookingUnitIndex];
                var convertedAmount = amountMl / multiplier;

                wordArray[i - 1] = convertedAmount.ToString("F2", CultureInfo.InvariantCulture);
                wordArray[i] = unit;
            }
            return wordArray;
        }

        private static string ConvertToSiUnits(string recipe)
        {
            recipe = FixDoubleWordedCookingUnits(recipe);
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                try
                {
                    StandardiseCookingUnit(index, words);
                }
                catch (InvalidRecipeException ex)
                {
                    throw;
                }
            }

            return string.Join(" ", words);
        }

        static void StandardiseCookingUnit(int index, string[] words)
        {
            var cookingUnit = words[index];
            var multiplier = FindMultiplier(cookingUnit);
            if (words[index] != "ml" && words[index] != "l")
            {
                if (multiplier == -1) return;
            }
            else if (words[index] == "l")
            {
                multiplier = 1000;
            }
            else 
            {
                multiplier = 1;   
            }

            var amountText = words[index - 1].Trim();

            var isNumber = ParseDouble(amountText, out var amount);

            if (!isNumber)
            {
                throw new InvalidRecipeException($"{amountText} is not a number.");
            }

            var amountMl = amount * multiplier;
            string[] unitAndAmount = SIUnitCalculator(amountMl);
            
            words[index] = unitAndAmount[0];
            words[index - 1] = unitAndAmount[1];
        }

        // Method to get correct ml or l count
        static string[] SIUnitCalculator(double ml) {
            string[] arr = new string[] { "", "" };
            if (ml > 100)
            {
                arr[0] = "l";
                arr[1] = (ml / 1000).ToString("F2", CultureInfo.InvariantCulture);
            }
            else {
                arr[0] = "ml";
                arr[1] = ml.ToString("F2", CultureInfo.InvariantCulture);
            }
            return arr;
        }

        static double FindMultiplier(string cookingUnit)
        {
            cookingUnit = cookingUnit.Replace("_", " ");
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
            else if (words[index] == "l")
            {
                var isNumber = ParseDouble(words[index - 1], out var ml);
                if (!isNumber) return -1;

                return ml * 1000;
            }
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
