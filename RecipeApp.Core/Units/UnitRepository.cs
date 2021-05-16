using RecipeApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp.Core.Units
{
    public class UnitRepository : IUnitRepository
    {
        private readonly Dictionary<string, double> _cookingUnits = new Dictionary<string, double>
        {
            { "gallon", 3790},
            { "quart", 950},
            { "pint", 470},
            { "cup", 240},
            { "fluid ounce", 29.57},
            { "tablespoon", 14.79},
            { "teaspoon", 4.93},
        };

        private readonly Dictionary<string, double> _siUnits = new Dictionary<string, double>
        {
            { "l", 1000},
            { "ml", 1},
        };

        public Unit GetClosestCookingUnit(Unit siUnit)
        {
            return GetProperUnit(_cookingUnits, siUnit);
        }

        public Unit GetClosestSiUnit(Unit cookingUnit)
        {
            return GetProperUnit(_siUnits, cookingUnit);
        }

        public bool TryFindMlCoefficient(Unit unitToConvert, out double coefficient)
        {
            coefficient = -1;
            foreach (var item in _cookingUnits.Union(_siUnits))
            {
                if (unitToConvert.Name.Equals(item.Key, StringComparison.OrdinalIgnoreCase) ||
                    unitToConvert.Name.Equals(item.Key + "s", StringComparison.OrdinalIgnoreCase))
                {
                    coefficient = item.Value;
                    return true;
                }
            }
            return false;
        }

        public bool TryFindUnit(string unitText, out Unit unit)
        {
            unit = new Unit { Name = unitText };

            if (
                _siUnits.Any(u =>
                u.Key.Equals(unitText.ToLower(), StringComparison.OrdinalIgnoreCase) ||
                (u.Key + "s").Equals(unitText.ToLower(), StringComparison.OrdinalIgnoreCase)))
            {
                unit.IsSiUnit = true;
                return true;
            }

            if (_cookingUnits.Any(u =>
                u.Key.Equals(unitText.ToLower(), StringComparison.OrdinalIgnoreCase) ||
                (u.Key + "s").Equals(unitText.ToLower(), StringComparison.OrdinalIgnoreCase)))
            {
                unit.IsSiUnit = false;
                return true;
            }

            return false;
        }

        private Unit ConvertToProperUnit(Dictionary<string, double> units, Unit unitToConvert)
        {
            return default;
        }

        private Unit GetProperUnit(Dictionary<string, double> units, Unit unitToConvert)
        {
            Unit smallestUnit = null;
            double amountInMl;

            if (TryFindMlCoefficient(unitToConvert, out double mlCoefficient))
            {
                amountInMl = unitToConvert.Amount * mlCoefficient;
                var smallestDifference = double.MaxValue;

                foreach (var unit in units)
                {
                    if (unit.Value > amountInMl) continue;
                    var currentDifference = amountInMl - unit.Value;

                    if (currentDifference < smallestDifference && TryFindUnit(unit.Key, out smallestUnit))
                    {
                        smallestDifference = currentDifference;
                        smallestUnit.Amount = amountInMl / unit.Value;
                    }
                }
            }

            if (smallestUnit is null) throw new UnitNotFoundException($"Conversion not found for unit '{unitToConvert.Name}'");
            return smallestUnit;
        }
    }
}