namespace ShoppingListApi.Models
{
    public class FixedTaxPolicy : ITaxPolicy
    {
        private readonly decimal _taxes;

        public FixedTaxPolicy(decimal taxes)
        {
            _taxes = taxes;
        }

        public decimal Apply(decimal price)
        {
            return price * _taxes;
        }
    }
}