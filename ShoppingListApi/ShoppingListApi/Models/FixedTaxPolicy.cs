namespace ShoppingListApi.Models
{
    public class FixedTaxPolicy : ITaxPolicy
    {
        public decimal Taxes { get; }

        public FixedTaxPolicy(decimal taxes)
        {
            Taxes = taxes;
        }

        public decimal Apply(decimal price)
        {
            return price * Taxes;
        }
    }
}