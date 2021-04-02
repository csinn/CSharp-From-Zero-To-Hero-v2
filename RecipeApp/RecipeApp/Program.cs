// Import classes from system namespace

using System;
using System.Collections.Generic;

// Holder of classes
namespace RecipeApp
{
    // Here is a list of standard cooking units:
    //    Cup	0.24 l
    //    Gallon  3.79 l
    //    Fluid Ounce	29.57 ml
    //    Pint    0.47 l
    //    Quart   0.95 l
    //    Tablespoon  14.79 ml
    //    Teaspoon    4.93 ml

    // Holder of functions and data
    class Program
    {
        // The less a function implements itself- the higher level it is
        // Main function simply the application- so it is the highest level function
        // It just consumes other functions.

        // Named block of code
        // cw + tab autocompletes to Console.WriteLine();
        // strongly typed means that I don't need to guess what I can do with a class or a variable
        // So, when I get errors, they will be before my application runs- in compile time.
        // Weekly typed means that there is no check on what a function or variable cna do.
        // We can do that with dynamic keyword: dynamic a; a.IsPerfectly.Fine().CsharpCode().
        static void Main(string[] args)
        {
            string ingredients =
                "1.5 cups all-purpose flour. 3.5 teaspoons baking powder. 1 teaspoon salt. 1 tablespoon white sugar. 1.25 cups milk. " +
                "1 egg. 3 tablespoons butter, melted";


            string recipe = StandardizeRecipe(ingredients);

            Console.WriteLine(recipe);
        }

        static string StandardizeRecipe(string recipe)
        {
            string[] words = recipe.Split(" ");
            List<string> sentenceList = new List<string>();
            string[] units = {"cup", "teaspoon", "tablespoon"};

            var unitsList = CreateDictionary();


            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                var isUnit = IsUnitOfCooking(word, unitsList);

                if (isUnit != "")
                {
                    ModifyUnitInSentence(sentenceList, words, i, isUnit, units, unitsList);
                    continue;
                }

                sentenceList.Add(word);
            }

            string sentence = CreateSentence(sentenceList);

            return sentence.Trim();
        }

        private static string CreateSentence(List<string> sentenceList)
        {
            string sentence = "";
            
            foreach (var word in sentenceList)
            {
                sentence += $"{word} ";
            }

            return sentence;
        }

        private static Dictionary<string, Func<double, double>> CreateDictionary()
        {
            Dictionary<string, Func<double, double>> unitsList = new Dictionary<string, Func<double, double>>();
            unitsList.Add("teaspoon", TeaspoonsToMl);
            unitsList.Add("tablespoon", TableSpoonsToMl);
            unitsList.Add("cup", CupsToMl);
            return unitsList;
        }

        private static void ModifyUnitInSentence(List<string> sentenceList, string[] words, int i, string isUnit,
            string[] units, Dictionary<string, Func<double, double>> unitsList)
        {
            string word;
            sentenceList.RemoveAt(sentenceList.Count - 1);
            string convertedMlAmount = PerformConversion(words[i - 1], isUnit, units, unitsList);
            sentenceList.Add(convertedMlAmount);

            word = "mililiters";
            sentenceList.Add(word);
        }

        static string PerformConversion(string num, string word, string[] units,
            Dictionary<string, Func<double, double>> unitsList)
        {
            bool isValidNumber = double.TryParse(num, out double unitCount);

            if (isValidNumber)
            {
                return FindAppropriateConversion(word, unitCount, units, unitsList);
            }

            Console.WriteLine("Error - PerformConversion - Not a valid number");

            return "";
        }

        static string FindAppropriateConversion(string word, double unitCount, string[] units,
            Dictionary<string, Func<double, double>> unitsList)
        {
            foreach (string unit in units)
            {
                string wordTrimmed = word.TrimEnd('s');

                if (unit.Equals(wordTrimmed, StringComparison.OrdinalIgnoreCase))
                {
                    return unitsList[unit].DynamicInvoke(unitCount).ToString();
                }
            }

            return "";
        }

        static string IsUnitOfCooking(string word, Dictionary<string, Func<double, double>> unitsList)
        {
            foreach (KeyValuePair<string, Func<double, double>> unit in unitsList)
            {
                string unitPlural = unit.Key + "s";
                if (unit.Key.Equals(word, StringComparison.OrdinalIgnoreCase) ||
                    (unitPlural.Equals(word, StringComparison.OrdinalIgnoreCase)))
                {
                    return word;
                }
            }

            return "";
        }
        static double TeaspoonsToMl(double teaspoons)
        {
            double ml = teaspoons * 4.93;

            return ml;
        }

        static double TableSpoonsToMl(double tablespoons)
        {
            double ml = tablespoons * 14.79;

            return ml;
        }

        static double CupsToMl(double cups)
        {
            double ml = cups * 236.588;

            return ml;
        }

    }
}