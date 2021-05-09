namespace ShoppingListApi
{
    public interface ITaxPolicy
    {
        public decimal Apply(decimal price);
    }
}