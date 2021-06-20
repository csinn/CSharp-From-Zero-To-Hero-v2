using ShoppingListApi.Extensions;

namespace ShoppingListApi.Db
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Amount { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int ShoppingListId { get; set; }
    }
}
