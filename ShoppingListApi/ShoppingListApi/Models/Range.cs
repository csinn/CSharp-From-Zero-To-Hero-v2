namespace ShoppingListApi
{
    public class Range
    {
        public decimal End { get; }
        public decimal Taxes { get; }

        public Range(decimal end, decimal taxes)
        {
            End = end;
            Taxes = taxes;
        }
    }
}