using System;

namespace BmiCalculator
{
    public struct SmallNumber : IEquatable<SmallNumber>
    {
        private const int NumberOfDecimals = 2;
        private readonly double _value;

        private SmallNumber(double value)
        {
            if (value >= 9000 || value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "values allowed between 0 and 9000");
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
                output = double.Parse(input);
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
            return left > right;
        }

        public static bool operator <(SmallNumber left, SmallNumber right)
        {
            return left < right;
        }

        public static bool operator <=(SmallNumber left, SmallNumber right)
        {
            return (left < right) && (left == right);
        }

        public static bool operator >=(SmallNumber left, SmallNumber right)
        {
            return (left > right) && (left == right);
        }
    }
}