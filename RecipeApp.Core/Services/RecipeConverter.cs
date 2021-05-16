using RecipeApp.Core.Exceptions;
using RecipeApp.Core.Units;
using System;
using System.Globalization;

namespace RecipeApp.Core.Services
{
    public class RecipeConverter
    {
        private readonly IUnitRepository _unitRepo;

        public RecipeConverter(IUnitRepository unitRepo)
        {
            _unitRepo = unitRepo;
        }

        public string ConvertRecipe(string recipe, bool isSiUnit)
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

        public string ConvertToCookingUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                try
                {
                    if (
                        TryParseUnit(index, words, out Unit parsedUnit) &&
                        parsedUnit.IsSiUnit)
                    {
                        ReplaceText(index, words, ConvertToCookingUnit(parsedUnit));
                    }
                }
                catch (InvalidRecipeException ex)
                {
                    Console.WriteLine($"Skipping word, because: {ex.Message}");
                }
            }

            return string.Join(" ", words);
        }

        public string ConvertToSiUnits(string recipe)
        {
            string[] words = recipe.Split(' ', '\n');

            for (int index = 0; index < words.Length; index++)
            {
                try
                {
                    if (
                        TryParseUnit(index, words, out Unit parsedUnit) &&
                        !parsedUnit.IsSiUnit)
                    {
                        ReplaceText(index, words, ConvertToSiUnit(parsedUnit));
                    }
                }
                catch (InvalidRecipeException ex)
                {
                    Console.WriteLine($"Skipping word, because: {ex.Message}");
                }
            }

            return string.Join(" ", words);
        }

        public bool TryConvertToLargerUnit(Unit unitToConvert, out Unit conversionResult)
        {
            conversionResult = unitToConvert;

            if (unitToConvert.IsSiUnit)
            {
                if (unitToConvert.Name == "ml" && unitToConvert.Amount > 100)
                {
                    conversionResult = new Unit
                    {
                        Amount = unitToConvert.Amount / 1000,
                        Name = "l",
                        IsSiUnit = true
                    };
                }
            }
            else
            {
                var unitInMl = ConvertToSiUnit(unitToConvert);
                conversionResult = ConvertToCookingUnit(unitInMl);
            }

            return conversionResult != unitToConvert;
        }

        public string UseLargerUnits(string words)
        {
            string[] splitted = words.Split(' ', '\n');

            for (int i = 0; i < splitted.Length; i++)
            {
                if (!TryParseUnit(i, splitted, out Unit unit)) continue;

                if (TryConvertToLargerUnit(unit, out Unit largerUnit))
                {
                    ReplaceText(i, splitted, largerUnit);
                }
            }

            return string.Join(" ", splitted);
        }

        private Unit ConvertToCookingUnit(Unit siUnit)
        {
            return _unitRepo.GetClosestCookingUnit(siUnit);
        }

        private Unit ConvertToSiUnit(Unit cookingUnit)
        {
            var siUnit = _unitRepo.GetClosestSiUnit(cookingUnit);
            TryConvertToLargerUnit(siUnit, out Unit largestSiUnit);
            return largestSiUnit;
        }

        private bool ParseDouble(string amountText, out double amount)
        {
            var isNumber = double.TryParse(
                amountText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out amount);

            return isNumber;
        }

        private void ReplaceText(int index, string[] words, Unit replacement)
        {
            words[index] = replacement.Name;
            words[index - 1] = replacement.Amount.ToString("F2", CultureInfo.InvariantCulture);
        }

        private bool TryParseUnit(int idx, string[] words, out Unit parsedUnit)
        {
            string unitText = words[idx];

            if (!_unitRepo.TryFindUnit(unitText, out parsedUnit) || !ParseDouble(words[idx - 1], out double amount))
            {
                return false;
            }

            parsedUnit.Amount = amount;

            return true;
        }
    }
}