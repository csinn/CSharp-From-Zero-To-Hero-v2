namespace ShoppingListApi
{
    public class ProgressiveTaxedPolicy : ITaxPolicy
    {
        private readonly Range[] _taxRange;

        public ProgressiveTaxedPolicy()
        {
            _taxRange = new []
            {
                new Range(10, 1m),
                new Range(20, 1.01m),
                new Range(100, 1.02m),
                new Range(1000, 1.1m),
                new Range(100000, 1.2m)
            };
        }

        public decimal Apply(decimal price)
        {
            for (int i = 0; i < _taxRange.Length; i++)
            {
                var range = _taxRange[i];
                if (price <= range.End)
                {
                    return price * range.Taxes;
                }
            }

            const decimal superTax = 2;
            return price * superTax;
        }
    }
}