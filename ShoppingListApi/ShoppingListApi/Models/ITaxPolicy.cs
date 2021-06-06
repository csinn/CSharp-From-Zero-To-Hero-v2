namespace ShoppingListApi.Models
{
    public interface ITaxPolicy
    {
        public decimal Apply(decimal price);
    }
}