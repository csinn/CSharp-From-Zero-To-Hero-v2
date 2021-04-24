using System;
using System.IO;

namespace RecipeApp.Core
{
    public class RecipeValidator
    {
        public static bool ValidateUnitsHaveAmounts(string recipe)
        {
            int unitCount = 0;
            int amountCount = 0;

            string[] words = recipe.Split(' ', '\n');
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (RecipeConverter.FindSiMultiplier(word) != -1)
                {
                    if (RecipeConverter.ParseDouble(words[i - 1], out _))
                    {
                        amountCount++;
                    }
                    unitCount++;
                }
            }

            return unitCount == amountCount;
        }

        [Obsolete("OpenFileDialog.Filter is sufficient!")]
        public static bool ValiateFileExtension(string filename)
        {
            return Path.GetExtension(filename)?.Equals(".recipe") ?? false;
        }
    }
}