﻿using System;
using System.Reflection;

namespace RecipeApp.Core.Units
{
    public abstract class BaseUnit : IConvertable
    {
        public double Amount { get; set; }
        public abstract string Name { get; }
        protected virtual double _toMl => Conversion.CookingUnits[Name];

        public virtual BaseUnit ConvertTo<T>() where T : BaseUnit, new()
        {
            var output = new T();
            var coefficient = _toMl / output._toMl;
            output.Amount = Amount * coefficient;

            return output;
        }

        public virtual BaseUnit ConvertTo(Type t)
        {
            var output = Assembly.GetExecutingAssembly().CreateInstance(t.FullName) as BaseUnit;
            var coefficient = _toMl / output._toMl;
            output.Amount = Amount * coefficient;

            return output;
        }

        public override string ToString()
        {
            return $"{Amount:F2} {Name}";
        }
    }
}