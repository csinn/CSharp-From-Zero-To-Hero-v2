using RecipeApp.Core.Units;
using System;
using System.IO;

namespace RecipeApp.Core.Services
{
    public class RecipeValidator
    {
        private readonly IUnitRepository _unitRepo;

        public RecipeValidator(IUnitRepository unitRepo)
        {
            _unitRepo = unitRepo;
        }

        public bool ValidateUnitsHaveAmounts(string recipe)
        {
            int unitCount = 0;
            int amountCount = 0;

            string[] words = recipe.Split(' ', '\n');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (_unitRepo.TryFindUnit(word, out Unit foundUnit))
                {
                    unitCount++;

                    if (double.TryParse(words[i - 1], out _))
                    {
                        amountCount++;
                    }
                }

            }

            return unitCount == amountCount;
        }

        [Obsolete("OpenFileDialog.Filter is sufficient!")]
        public bool ValiateFileExtension(string filename)
        {
            return Path.GetExtension(filename)?.Equals(".recipe") ?? false;
        }
    }
}