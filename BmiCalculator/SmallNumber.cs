using System;
using System.Globalization;

namespace BmiCalculator
{
    public readonly struct SmallNumber : IEquatable<SmallNumber>
    {
        private const int NumberOfDecimals = 2;
        private readonly double _value;
        
        private const double LowerLimit = 0;
        private const double UpperLimit = 9000;
        
        private SmallNumber(double value)
        {
            
            if (value < LowerLimit || value >= UpperLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "power level allowed in 0-9000 range");
            }
            _value = Math.Round(value, NumberOfDecimals);
        }

        public static bool TryParse(string input, out SmallNumber output)
        {
            output = default;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            try
            {
                output = new SmallNumber(double.Parse(input));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static SmallNumber operator *(SmallNumber left, SmallNumber right)
        {
            return new SmallNumber(left._value * right._value);
        }

        public static SmallNumber operator /(SmallNumber left, SmallNumber right)
        {
            if (right == 0)
            {
                throw new DivideByZeroException();
            }

            return new SmallNumber(left._value / right._value);
        }

        public static SmallNumber operator +(SmallNumber left, SmallNumber right)
        {
            return new SmallNumber(left._value + right._value);
        }

        public static SmallNumber operator -(SmallNumber left, SmallNumber right)
        {
            return new SmallNumber(left._value - right._value);
        }

        public static implicit operator SmallNumber(int value)
        {
            return new SmallNumber(value);
        }

        public static implicit operator SmallNumber(double value)
        {
            return new SmallNumber(value);
        }

        public static implicit operator SmallNumber(float value)
        {
            return new SmallNumber(value);
        }

        public static implicit operator SmallNumber(decimal value)
        {
            return new SmallNumber((double)value);
        }

        public static explicit operator int(SmallNumber value)
        {
            return (int)value._value;
        }

        public static explicit operator decimal(SmallNumber value)
        {
            return (decimal)value._value;
        }

        public static explicit operator float(SmallNumber value)
        {
            return (float)value._value;
        }

        public bool Equals(SmallNumber other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            return obj is SmallNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(SmallNumber left, SmallNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SmallNumber left, SmallNumber right)
        {
            return !left.Equals(right);
        }

        public static bool operator >(SmallNumber left, SmallNumber right)
        {
            return (double)left > (double)right;
        }

        public static bool operator <(SmallNumber left, SmallNumber right)
        {
            return (double)left < (double)right;
        }

        public static bool operator <=(SmallNumber left, SmallNumber right)
        {
            return (left < right) && (left == right);
        }

        public static bool operator >=(SmallNumber left, SmallNumber right)
        {
            return (left > right) && (left == right);
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
